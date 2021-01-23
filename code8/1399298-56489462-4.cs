	abstract class TaskBase<TResult> : Task<TResult>
	{
		readonly static FieldInfo m_action =
		   typeof(Task).GetField("m_action", BindingFlags.Instance | BindingFlags.NonPublic);
		readonly static Func<TResult> _dummy = () => default;
		public TaskBase(CancellationToken ct, TaskCreationOptions opts)
			: base(_dummy, ct, opts) =>
				m_action.SetValue(this, (Func<TResult>)function);
		public TaskBase(CancellationToken ct)
			: this(ct, TaskCreationOptions.None)
		{ }
		public TaskBase(TaskCreationOptions opts)
			: this(default, opts)
		{ }
		public TaskBase()
			: this(default, TaskCreationOptions.None)
		{ }
		protected abstract TResult function();  // <-- override with your work code
	};
