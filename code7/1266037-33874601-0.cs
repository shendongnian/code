	public class AsyncLazy<T>
	{
		static class LazyHelpers
		{
			internal static readonly object PUBLICATION_ONLY_SENTINEL = new object();
		}
		class Boxed
		{
			internal Boxed(T value)
			{
				this.value = value;
			}
			internal readonly T value;
		}
		class LazyInternalExceptionHolder
		{
			internal ExceptionDispatchInfo m_edi;
			internal LazyInternalExceptionHolder(Exception ex)
			{
				m_edi = ExceptionDispatchInfo.Capture(ex);
			}
		}
		static readonly Func<Task<T>> alreadyInvokedSentinel = delegate
		{
			Contract.Assert(false, "alreadyInvokedSentinel should never be invoked.");
			return default(Task<T>);
		};
		private object boxed;
		[NonSerialized]
		private Func<Task<T>> valueFactory;
		[NonSerialized]
		private object threadSafeObj;
		public AsyncLazy()
			: this(LazyThreadSafetyMode.ExecutionAndPublication)
		{
		}
		public AsyncLazy(Func<Task<T>> valueFactory)
					: this(valueFactory, LazyThreadSafetyMode.ExecutionAndPublication)
		{
		}
		public AsyncLazy(bool isThreadSafe) :
					this(isThreadSafe ?
						 LazyThreadSafetyMode.ExecutionAndPublication :
						 LazyThreadSafetyMode.None)
		{
		}
		public AsyncLazy(LazyThreadSafetyMode mode)
		{
			threadSafeObj = GetObjectFromMode(mode);
		}
		public AsyncLazy(Func<Task<T>> valueFactory, bool isThreadSafe)
					: this(valueFactory, isThreadSafe ? LazyThreadSafetyMode.ExecutionAndPublication : LazyThreadSafetyMode.None)
		{
		}
		public AsyncLazy(Func<Task<T>> valueFactory, LazyThreadSafetyMode mode)
		{
			if (valueFactory == null)
				throw new ArgumentNullException("valueFactory");
			threadSafeObj = GetObjectFromMode(mode);
			this.valueFactory = valueFactory;
		}
		private static object GetObjectFromMode(LazyThreadSafetyMode mode)
		{
			if (mode == LazyThreadSafetyMode.ExecutionAndPublication)
				return new object();
			if (mode == LazyThreadSafetyMode.PublicationOnly)
				return LazyHelpers.PUBLICATION_ONLY_SENTINEL;
			if (mode != LazyThreadSafetyMode.None)
				throw new ArgumentOutOfRangeException("mode");
			return null; // None mode
		}
		public override string ToString()
		{
			return IsValueCreated ? ((Boxed) boxed).value.ToString() : "NoValue";
		}
		internal LazyThreadSafetyMode Mode
		{
			get
			{
				if (threadSafeObj == null) return LazyThreadSafetyMode.None;
				if (threadSafeObj == (object)LazyHelpers.PUBLICATION_ONLY_SENTINEL) return LazyThreadSafetyMode.PublicationOnly;
				return LazyThreadSafetyMode.ExecutionAndPublication;
			}
		}
		internal bool IsValueFaulted
		{
			get { return boxed is LazyInternalExceptionHolder; }
		}
		public bool IsValueCreated
		{
			get
			{
				return boxed != null && boxed is Boxed;
			}
		}
		public async Task<T> FetchValueAsync()
		{
			Boxed boxed = null;
			if (this.boxed != null)
			{
				// Do a quick check up front for the fast path.
				boxed = this.boxed as Boxed;
				if (boxed != null)
				{
					return boxed.value;
				}
				LazyInternalExceptionHolder exc = this.boxed as LazyInternalExceptionHolder;
				exc.m_edi.Throw();
			}
			return await LazyInitValue();
		}
		/// <summary>
		/// local helper method to initialize the value 
		/// </summary>
		/// <returns>The inititialized T value</returns>
		private async Task<T> LazyInitValue()
		{
			Boxed boxed = null;
			LazyThreadSafetyMode mode = Mode;
			if (mode == LazyThreadSafetyMode.None)
			{
				boxed = await CreateValue();
				this.boxed = boxed;
			}
			else if (mode == LazyThreadSafetyMode.PublicationOnly)
			{
				boxed = await CreateValue();
				if (boxed == null ||
					Interlocked.CompareExchange(ref this.boxed, boxed, null) != null)
				{
					boxed = (Boxed)this.boxed;
				}
				else
				{
					valueFactory = alreadyInvokedSentinel;
				}
			}
			else
			{
				object threadSafeObject = Volatile.Read(ref threadSafeObj);
				bool lockTaken = false;
				try
				{
					if (threadSafeObject != (object)alreadyInvokedSentinel)
						Monitor.Enter(threadSafeObject, ref lockTaken);
					else
						Contract.Assert(this.boxed != null);
					if (this.boxed == null)
					{
						boxed = await CreateValue();
						this.boxed = boxed;
						Volatile.Write(ref threadSafeObj, alreadyInvokedSentinel);
					}
					else
					{
						boxed = this.boxed as Boxed;
						if (boxed == null) // it is not Boxed, so it is a LazyInternalExceptionHolder
						{
							LazyInternalExceptionHolder exHolder = this.boxed as LazyInternalExceptionHolder;
							Contract.Assert(exHolder != null);
							exHolder.m_edi.Throw();
						}
					}
				}
				finally
				{
					if (lockTaken)
						Monitor.Exit(threadSafeObject);
				}
			}
			Contract.Assert(boxed != null);
			return boxed.value;
		}
		/// <summary>Creates an instance of T using valueFactory in case its not null or use reflection to create a new T()</summary>
		/// <returns>An instance of Boxed.</returns>
		private async Task<Boxed> CreateValue()
		{
			Boxed localBoxed = null;
			LazyThreadSafetyMode mode = Mode;
			if (valueFactory != null)
			{
				try
				{
					// check for recursion
					if (mode != LazyThreadSafetyMode.PublicationOnly && valueFactory == alreadyInvokedSentinel)
						throw new InvalidOperationException("Recursive call to Value property");
					Func<Task<T>> factory = valueFactory;
					if (mode != LazyThreadSafetyMode.PublicationOnly) // only detect recursion on None and ExecutionAndPublication modes
					{
						valueFactory = alreadyInvokedSentinel;
					}
					else if (factory == alreadyInvokedSentinel)
					{
						// Another thread ----d with us and beat us to successfully invoke the factory.
						return null;
					}
					localBoxed = new Boxed(await factory());
				}
				catch (Exception ex)
				{
					if (mode != LazyThreadSafetyMode.PublicationOnly) // don't cache the exception for PublicationOnly mode
						boxed = new LazyInternalExceptionHolder(ex);
					throw;
				}
			}
			else
			{
				try
				{
					localBoxed = new Boxed((T)Activator.CreateInstance(typeof(T)));
				}
				catch (MissingMethodException)
				{
					Exception ex = new MissingMemberException("Missing parametersless constructor");
					if (mode != LazyThreadSafetyMode.PublicationOnly) // don't cache the exception for PublicationOnly mode
						boxed = new LazyInternalExceptionHolder(ex);
					throw ex;
				}
			}
			return localBoxed;
		}
	}
