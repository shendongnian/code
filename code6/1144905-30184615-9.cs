	namespace Utilities
	{
		using System;
		using System.Collections;
		using System.Collections.Generic;
		using System.Collections.ObjectModel;
		using System.Data.Entity;
		using System.Data.Entity.Infrastructure;
		using System.Linq;
		using System.Linq.Expressions;
		using System.Reflection;
		using System.Threading;
		using System.Threading.Tasks;
		public class ProxyDbContext : DbContext
		{
			protected static readonly MethodInfo ProxifySetsMethod = typeof(ProxyDbContext).GetMethod("ProxifySets", BindingFlags.Instance | BindingFlags.NonPublic);
			protected static class ProxyDbContexSetter<TContext> where TContext : ProxyDbContext
			{
				public static readonly Action<TContext> Do = x => { };
				static ProxyDbContexSetter()
				{
					var properties = typeof(TContext).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
					ParameterExpression context = Expression.Parameter(typeof(TContext), "context");
					FieldInfo manipulatorField = typeof(ProxyDbContext).GetField("Manipulator", BindingFlags.Instance | BindingFlags.Public);
					Expression manipulator = Expression.Field(context, manipulatorField);
					var sets = new List<Expression>();
					foreach (PropertyInfo property in properties)
					{
						if (property.GetMethod == null)
						{
							continue;
						}
						MethodInfo setMethod = property.SetMethod;
						if (setMethod != null && !setMethod.IsPublic)
						{
							continue;
						}
						Type type = property.PropertyType;
						Type entityType = GetIDbSetTypeArgument(type);
						if (entityType == null)
						{
							continue;
						}
						if (!type.IsAssignableFrom(typeof(DbSet<>).MakeGenericType(entityType)))
						{
							continue;
						}
						Type dbSetType = typeof(DbSet<>).MakeGenericType(entityType);
						ConstructorInfo constructor = typeof(ProxyDbSet<>)
							.MakeGenericType(entityType)
							.GetConstructor(new[] 
						{ 
							dbSetType, 
							typeof(Func<bool, Expression, Expression>) 
						});
						MemberExpression property2 = Expression.Property(context, property);
						BinaryExpression assign = Expression.Assign(property2, Expression.New(constructor, Expression.Convert(property2, dbSetType), manipulator));
						sets.Add(assign);
					}
					Expression<Action<TContext>> lambda = Expression.Lambda<Action<TContext>>(Expression.Block(sets), context);
					Do = lambda.Compile();
				}
				// Gets the T of IDbSetlt;T&gt;
				private static Type GetIDbSetTypeArgument(Type type)
				{
					IEnumerable<Type> interfaces = type.IsInterface ?
						new[] { type }.Concat(type.GetInterfaces()) :
						type.GetInterfaces();
					Type argument = (from x in interfaces
									 where x.IsGenericType
									 let gt = x.GetGenericTypeDefinition()
									 where gt == typeof(IDbSet<>)
									 select x.GetGenericArguments()[0]).SingleOrDefault();
					return argument;
				}
			}
			public readonly Func<bool, Expression, Expression> Manipulator;
			/// <summary>
			/// 
			/// </summary>
			/// <param name="manipulator">First parameter: true for Execute, false for CreateQuery.</param>
			/// <param name="resetSets">True to have all the DbSet&lt;TEntity&gt; and IDbSet&lt;TEntity&gt; proxified</param>
			public ProxyDbContext(Func<bool, Expression, Expression> manipulator, bool resetSets = true)
			{
				Manipulator = manipulator;
				if (resetSets)
				{
					ProxifySetsMethod.MakeGenericMethod(GetType()).Invoke(this, null);
				}
			}
			/// <summary>
			/// 
			/// </summary>
			/// <param name="nameOrConnectionString"></param>
			/// <param name="manipulator">First parameter: true for Execute, false for CreateQuery.</param>
			/// <param name="resetSets">True to have all the DbSet&lt;TEntity&gt; and IDbSet&lt;TEntity&gt; proxified</param>
			public ProxyDbContext(string nameOrConnectionString, Func<bool, Expression, Expression> manipulator, bool resetSets = true)
				: base(nameOrConnectionString)
			{
				Manipulator = manipulator;
				var set = base.Set(typeof(Workbench.Parent)).GetType();
				var inter = set.GetInterfaces();
				if (resetSets)
				{
					ProxifySetsMethod.MakeGenericMethod(GetType()).Invoke(this, null);
				}
			}
			protected void ProxifySets<TContext>() where TContext : ProxyDbContext
			{
				ProxyDbContexSetter<TContext>.Do((TContext)this);
			}
			public override DbSet<TEntity> Set<TEntity>()
			{
				return new ProxyDbSet<TEntity>(base.Set<TEntity>(), Manipulator);
			}
			public override DbSet Set(Type entityType)
			{
				DbSet set = base.Set(entityType);
				ConstructorInfo constructor = typeof(ProxyDbSetNonGeneric<>)
					.MakeGenericType(entityType)
					.GetConstructor(new[] 
					{ 
						typeof(DbSet), 
						typeof(Func<bool, Expression, Expression>) 
					});
				return (DbSet)constructor.Invoke(new object[] { set, Manipulator });
			}
		}
		/// <summary>
		/// The DbSet, that is implemented as InternalDbSet&lt&gt; by EF.
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		public class ProxyDbSetNonGeneric<TEntity> : DbSet, IQueryable<TEntity>, IEnumerable<TEntity>, IDbAsyncEnumerable<TEntity>, IQueryable, IEnumerable, IDbAsyncEnumerable where TEntity : class
		{
			protected readonly DbSet BaseDbSet;
			protected readonly IQueryable<TEntity> ProxyQueryable;
			public readonly Func<bool, Expression, Expression> Manipulator;
			protected readonly FieldInfo InternalSetField = typeof(DbSet).GetField("_internalSet", BindingFlags.Instance | BindingFlags.NonPublic);
			/// <summary>
			/// 
			/// </summary>
			/// <param name="baseDbSet"></param>
			/// <param name="manipulator">First parameter: true for Execute, false for CreateQuery.</param>
			public ProxyDbSetNonGeneric(DbSet baseDbSet, Func<bool, Expression, Expression> manipulator)
			{
				BaseDbSet = baseDbSet;
				IQueryProvider provider = ((IQueryable)baseDbSet).Provider;
				ProxyDbProvider proxyDbProvider = new ProxyDbProvider(provider, manipulator);
				ProxyQueryable = proxyDbProvider.CreateQuery<TEntity>(((IQueryable)baseDbSet).Expression);
				Manipulator = manipulator;
				if (InternalSetField != null)
				{
					InternalSetField.SetValue(this, InternalSetField.GetValue(baseDbSet));
				}
			}
			/// <summary>
			/// 
			/// </summary>
			/// <param name="baseDbSet"></param>
			/// <param name="proxyQueryable"></param>
			/// <param name="manipulator">First parameter: true for Execute, false for CreateQuery.</param>
			public ProxyDbSetNonGeneric(DbSet baseDbSet, ProxyQueryable<TEntity> proxyQueryable, Func<bool, Expression, Expression> manipulator)
			{
				BaseDbSet = baseDbSet;
				ProxyQueryable = proxyQueryable;
				Manipulator = manipulator;
				if (InternalSetField != null)
				{
					InternalSetField.SetValue(this, InternalSetField.GetValue(baseDbSet));
				}
			}
			public override object Add(object entity)
			{
				return BaseDbSet.Add(entity);
			}
			public override IEnumerable AddRange(IEnumerable entities)
			{
				return BaseDbSet.AddRange(entities);
			}
			public override DbQuery AsNoTracking()
			{
				return new ProxyDbSetNonGeneric<TEntity>(BaseDbSet, new ProxyQueryable<TEntity>((ProxyDbProvider)ProxyQueryable.Provider, (IQueryable<TEntity>)BaseDbSet.AsNoTracking()), Manipulator);
			}
			[Obsolete]
			public override DbQuery AsStreaming()
			{
	#pragma warning disable 618
				return new ProxyDbSetNonGeneric<TEntity>(BaseDbSet, new ProxyQueryable<TEntity>((ProxyDbProvider)ProxyQueryable.Provider, (IQueryable<TEntity>)BaseDbSet.AsStreaming()), Manipulator);
	#pragma warning restore 618
			}
			public override object Attach(object entity)
			{
				return BaseDbSet.Attach(entity);
			}
			public override object Create(Type derivedEntityType)
			{
				return BaseDbSet.Create(derivedEntityType);
			}
			public override object Create()
			{
				return BaseDbSet.Create();
			}
			public override object Find(params object[] keyValues)
			{
				return BaseDbSet.Find(keyValues);
			}
			public override Task<object> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
			{
				return BaseDbSet.FindAsync(cancellationToken, keyValues);
			}
			public override Task<object> FindAsync(params object[] keyValues)
			{
				return BaseDbSet.FindAsync(keyValues);
			}
			public override DbQuery Include(string path)
			{
				return new ProxyDbSetNonGeneric<TEntity>(BaseDbSet, new ProxyQueryable<TEntity>((ProxyDbProvider)ProxyQueryable.Provider, (IQueryable<TEntity>)BaseDbSet.Include(path)), Manipulator);
			}
			public override IList Local
			{
				get
				{
					return BaseDbSet.Local;
				}
			}
			public override object Remove(object entity)
			{
				return BaseDbSet.Remove(entity);
			}
			public override IEnumerable RemoveRange(IEnumerable entities)
			{
				return BaseDbSet.RemoveRange(entities);
			}
			public override DbSqlQuery SqlQuery(string sql, params object[] parameters)
			{
				return BaseDbSet.SqlQuery(sql, parameters);
			}
			IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
			{
				return ProxyQueryable.GetEnumerator();
			}
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable)ProxyQueryable).GetEnumerator();
			}
			Type IQueryable.ElementType
			{
				get { return ProxyQueryable.ElementType; }
			}
			Expression IQueryable.Expression
			{
				get { return ProxyQueryable.Expression; }
			}
			IQueryProvider IQueryable.Provider
			{
				get { return ProxyQueryable.Provider; }
			}
			IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
			{
				return ((IDbAsyncEnumerable<TEntity>)ProxyQueryable).GetAsyncEnumerator();
			}
			IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
			{
				return ((IDbAsyncEnumerable)ProxyQueryable).GetAsyncEnumerator();
			}
			public override string ToString()
			{
				return ProxyQueryable.ToString();
			}
		}
		public class ProxyDbSet<TEntity> : DbSet<TEntity>, IQueryable<TEntity>, IEnumerable<TEntity>, IDbAsyncEnumerable<TEntity>, IQueryable, IEnumerable, IDbAsyncEnumerable where TEntity : class
		{
			protected readonly DbSet<TEntity> BaseDbSet;
			protected readonly IQueryable<TEntity> ProxyQueryable;
			public readonly Func<bool, Expression, Expression> Manipulator;
			protected readonly FieldInfo InternalSetField = typeof(DbSet<TEntity>).GetField("_internalSet", BindingFlags.Instance | BindingFlags.NonPublic);
			/// <summary>
			/// 
			/// </summary>
			/// <param name="baseDbSet"></param>
			/// <param name="manipulator">First parameter: true for Execute, false for CreateQuery.</param>
			public ProxyDbSet(DbSet<TEntity> baseDbSet, Func<bool, Expression, Expression> manipulator)
			{
				BaseDbSet = baseDbSet;
				IQueryProvider provider = ((IQueryable)baseDbSet).Provider;
				ProxyDbProvider proxyDbProvider = new ProxyDbProvider(provider, manipulator);
				ProxyQueryable = proxyDbProvider.CreateQuery<TEntity>(((IQueryable)baseDbSet).Expression);
				Manipulator = manipulator;
				if (InternalSetField != null)
				{
					InternalSetField.SetValue(this, InternalSetField.GetValue(baseDbSet));
				}
			}
			/// <summary>
			/// 
			/// </summary>
			/// <param name="baseDbSet"></param>
			/// <param name="proxyQueryable"></param>
			/// <param name="manipulator">First parameter: true for Execute, false for CreateQuery.</param>
			public ProxyDbSet(DbSet<TEntity> baseDbSet, ProxyQueryable<TEntity> proxyQueryable, Func<bool, Expression, Expression> manipulator)
			{
				BaseDbSet = baseDbSet;
				ProxyQueryable = proxyQueryable;
				Manipulator = manipulator;
				if (InternalSetField != null)
				{
					InternalSetField.SetValue(this, InternalSetField.GetValue(baseDbSet));
				}
			}
			public override TEntity Add(TEntity entity)
			{
				return BaseDbSet.Add(entity);
			}
			public override IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
			{
				return BaseDbSet.AddRange(entities);
			}
			public override DbQuery<TEntity> AsNoTracking()
			{
				return new ProxyDbSet<TEntity>(BaseDbSet, new ProxyQueryable<TEntity>((ProxyDbProvider)ProxyQueryable.Provider, BaseDbSet.AsNoTracking()), Manipulator);
			}
			[Obsolete]
			public override DbQuery<TEntity> AsStreaming()
			{
	#pragma warning disable 618
				return new ProxyDbSet<TEntity>(BaseDbSet, new ProxyQueryable<TEntity>((ProxyDbProvider)ProxyQueryable.Provider, BaseDbSet.AsStreaming()), Manipulator);
	#pragma warning restore 618
			}
			public override TEntity Attach(TEntity entity)
			{
				return BaseDbSet.Attach(entity);
			}
			public override TDerivedEntity Create<TDerivedEntity>()
			{
				return BaseDbSet.Create<TDerivedEntity>();
			}
			public override TEntity Create()
			{
				return BaseDbSet.Create();
			}
			public override TEntity Find(params object[] keyValues)
			{
				return BaseDbSet.Find(keyValues);
			}
			public override Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
			{
				return BaseDbSet.FindAsync(cancellationToken, keyValues);
			}
			public override Task<TEntity> FindAsync(params object[] keyValues)
			{
				return BaseDbSet.FindAsync(keyValues);
			}
			public override DbQuery<TEntity> Include(string path)
			{
				return new ProxyDbSet<TEntity>(BaseDbSet, new ProxyQueryable<TEntity>((ProxyDbProvider)ProxyQueryable.Provider, BaseDbSet.Include(path)), Manipulator);
			}
			public override ObservableCollection<TEntity> Local
			{
				get
				{
					return BaseDbSet.Local;
				}
			}
			public override TEntity Remove(TEntity entity)
			{
				return BaseDbSet.Remove(entity);
			}
			public override IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
			{
				return BaseDbSet.RemoveRange(entities);
			}
			public override DbSqlQuery<TEntity> SqlQuery(string sql, params object[] parameters)
			{
				return BaseDbSet.SqlQuery(sql, parameters);
			}
			IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
			{
				return ProxyQueryable.GetEnumerator();
			}
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable)ProxyQueryable).GetEnumerator();
			}
			Type IQueryable.ElementType
			{
				get { return ProxyQueryable.ElementType; }
			}
			Expression IQueryable.Expression
			{
				get { return ProxyQueryable.Expression; }
			}
			IQueryProvider IQueryable.Provider
			{
				get { return ProxyQueryable.Provider; }
			}
			IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
			{
				return ((IDbAsyncEnumerable<TEntity>)ProxyQueryable).GetAsyncEnumerator();
			}
			IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
			{
				return ((IDbAsyncEnumerable)ProxyQueryable).GetAsyncEnumerator();
			}
			public override string ToString()
			{
				return ProxyQueryable.ToString();
			}
			// Note that the operator isn't virtual! If you do:
			// DbSet<Foo> foo = new ProxyDbSet<Foo>(...)
			// DbSet foo2 = (DbSet)foo;
			// Then you'll have a non-proxed DbSet!
			public static implicit operator ProxyDbSetNonGeneric<TEntity>(ProxyDbSet<TEntity> entry)
			{
				return new ProxyDbSetNonGeneric<TEntity>((DbSet)entry.BaseDbSet, entry.Manipulator);
			}
		}
		public class ProxyDbProvider : IQueryProvider, IDbAsyncQueryProvider
		{
			protected readonly IQueryProvider BaseQueryProvider;
			public readonly Func<bool, Expression, Expression> Manipulator;
			/// <summary>
			/// 
			/// </summary>
			/// <param name="baseQueryProvider"></param>
			/// <param name="manipulator">First parameter: true for Execute, false for CreateQuery.</param>
			public ProxyDbProvider(IQueryProvider baseQueryProvider, Func<bool, Expression, Expression> manipulator)
			{
				BaseQueryProvider = baseQueryProvider;
				Manipulator = manipulator;
			}
			public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
			{
				Expression expression2 = Manipulator != null ? Manipulator(false, expression) : expression;
				IQueryable<TElement> query = BaseQueryProvider.CreateQuery<TElement>(expression2);
				IQueryProvider provider = query.Provider;
				ProxyDbProvider proxy = provider == BaseQueryProvider ? this : new ProxyDbProvider(provider, Manipulator);
				return new ProxyQueryable<TElement>(proxy, query);
			}
			protected static readonly MethodInfo CreateQueryNonGenericToGenericMethod = typeof(ProxyDbProvider).GetMethod("CreateQueryNonGenericToGeneric", BindingFlags.Static | BindingFlags.NonPublic);
			public IQueryable CreateQuery(Expression expression)
			{
				Expression expression2 = Manipulator != null ? Manipulator(false, expression) : expression;
				IQueryable query = BaseQueryProvider.CreateQuery(expression2);
				IQueryProvider provider = query.Provider;
				ProxyDbProvider proxy = provider == BaseQueryProvider ? this : new ProxyDbProvider(provider, Manipulator);
				Type entityType = GetIQueryableTypeArgument(query.GetType());
				if (entityType == null)
				{
					return new ProxyQueryable(proxy, query);
				}
				else
				{
					return (IQueryable)CreateQueryNonGenericToGenericMethod.MakeGenericMethod(entityType).Invoke(null, new object[] { proxy, query });
				}
			}
			protected static ProxyQueryable<TElement> CreateQueryNonGenericToGeneric<TElement>(ProxyDbProvider proxy, IQueryable<TElement> query)
			{
				return new ProxyQueryable<TElement>(proxy, query);
			}
			public TResult Execute<TResult>(Expression expression)
			{
				Expression expression2 = Manipulator != null ? Manipulator(true, expression) : expression;
				return BaseQueryProvider.Execute<TResult>(expression2);
			}
			public object Execute(Expression expression)
			{
				Expression expression2 = Manipulator != null ? Manipulator(true, expression) : expression;
				return BaseQueryProvider.Execute(expression2);
			}
			// Gets the T of IQueryablelt;T&gt;
			protected static Type GetIQueryableTypeArgument(Type type)
			{
				IEnumerable<Type> interfaces = type.IsInterface ?
					new[] { type }.Concat(type.GetInterfaces()) :
					type.GetInterfaces();
				Type argument = (from x in interfaces
								 where x.IsGenericType
								 let gt = x.GetGenericTypeDefinition()
								 where gt == typeof(IQueryable<>)
								 select x.GetGenericArguments()[0]).FirstOrDefault();
				return argument;
			}
			public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
			{
				var asyncQueryProvider = BaseQueryProvider as IDbAsyncQueryProvider;
				if (asyncQueryProvider == null)
				{
					throw new NotSupportedException();
				}
				Expression expression2 = Manipulator != null ? Manipulator(true, expression) : expression;
				return asyncQueryProvider.ExecuteAsync<TResult>(expression2, cancellationToken);
			}
			public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken)
			{
				var asyncQueryProvider = BaseQueryProvider as IDbAsyncQueryProvider;
				if (asyncQueryProvider == null)
				{
					throw new NotSupportedException();
				}
				Expression expression2 = Manipulator != null ? Manipulator(true, expression) : expression;
				return asyncQueryProvider.ExecuteAsync(expression2, cancellationToken);
			}
		}
		public class ProxyQueryable : IOrderedQueryable, IQueryable, IEnumerable, IDbAsyncEnumerable
		{
			protected readonly ProxyDbProvider ProxyDbProvider;
			protected readonly IQueryable BaseQueryable;
			public ProxyQueryable(ProxyDbProvider proxyDbProvider, IQueryable baseQueryable)
			{
				ProxyDbProvider = proxyDbProvider;
				BaseQueryable = baseQueryable;
			}
			public IEnumerator GetEnumerator()
			{
				return BaseQueryable.GetEnumerator();
			}
			public Type ElementType
			{
				get { return BaseQueryable.ElementType; }
			}
			public Expression Expression
			{
				get { return BaseQueryable.Expression; }
			}
			public IQueryProvider Provider
			{
				get { return ProxyDbProvider; }
			}
			public override string ToString()
			{
				return BaseQueryable.ToString();
			}
			IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
			{
				var asyncEnumerator = BaseQueryable as IDbAsyncEnumerable;
				if (asyncEnumerator == null)
				{
					throw new NotSupportedException();
				}
				return asyncEnumerator.GetAsyncEnumerator();
			}
		}
		public class ProxyQueryable<TElement> : IOrderedQueryable<TElement>, IQueryable<TElement>, IEnumerable<TElement>, IDbAsyncEnumerable<TElement>, IOrderedQueryable, IQueryable, IEnumerable, IDbAsyncEnumerable
		{
			protected readonly ProxyDbProvider ProxyDbProvider;
			protected readonly IQueryable<TElement> BaseQueryable;
			public ProxyQueryable(ProxyDbProvider proxyDbProvider, IQueryable<TElement> baseQueryable)
			{
				ProxyDbProvider = proxyDbProvider;
				BaseQueryable = baseQueryable;
			}
			public IEnumerator<TElement> GetEnumerator()
			{
				return BaseQueryable.GetEnumerator();
			}
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable)BaseQueryable).GetEnumerator();
			}
			public Type ElementType
			{
				get { return BaseQueryable.ElementType; }
			}
			public Expression Expression
			{
				get { return BaseQueryable.Expression; }
			}
			public IQueryProvider Provider
			{
				get { return ProxyDbProvider; }
			}
			public override string ToString()
			{
				return BaseQueryable.ToString();
			}
			public IDbAsyncEnumerator<TElement> GetAsyncEnumerator()
			{
				var asyncEnumerator = BaseQueryable as IDbAsyncEnumerable<TElement>;
				if (asyncEnumerator == null)
				{
					throw new NotSupportedException();
				}
				return asyncEnumerator.GetAsyncEnumerator();
			}
			IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
			{
				var asyncEnumerator = BaseQueryable as IDbAsyncEnumerable;
				if (asyncEnumerator == null)
				{
					throw new NotSupportedException();
				}
				return asyncEnumerator.GetAsyncEnumerator();
			}
		}
	}
