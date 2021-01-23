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
    
        public class ProxyDbSet<TEntity> : DbSet<TEntity>, IQueryable<TEntity>, IEnumerable<TEntity>, IQueryable, IEnumerable where TEntity : class
        {
            protected readonly DbSet<TEntity> BaseDbSet;
            protected readonly ProxyQueryable<TEntity> ProxyQueryable;
    
            public ProxyDbSet(DbSet<TEntity> baseDbSet, Func<Expression, Expression> manipulator = null)
            {
                IQueryProvider provider = ((IQueryable)baseDbSet).Provider;
                ProxyDbProvider proxyDbProvider = new ProxyDbProvider(provider, manipulator);
                ProxyQueryable = (ProxyQueryable<TEntity>)(proxyDbProvider.CreateQuery<TEntity>(((IQueryable)baseDbSet).Expression));
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
                return BaseDbSet.AsNoTracking();
            }
    
            [Obsolete]
            public override DbQuery<TEntity> AsStreaming()
            {
    #pragma warning disable 618
                return BaseDbSet.AsStreaming();
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
    
            public override DbQuery<TEntity> Include(string path)
            {
                return BaseDbSet.Include(path);
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
        }
    
        public class ProxyDbProvider : IQueryProvider
        {
            protected readonly IQueryProvider BaseQueryProvider;
            protected readonly Func<Expression, Expression> Manipulator;
    
            public ProxyDbProvider(IQueryProvider baseQueryProvider, Func<Expression, Expression> manipulator)
            {
                BaseQueryProvider = baseQueryProvider;
                Manipulator = manipulator;
            }
    
            public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
            {
                return CreateQueryImpl<TElement>(expression);
            }
    
            protected static readonly MethodInfo CreateQueryImplMethod = typeof(ProxyDbProvider).GetMethod("CreateQueryImpl", BindingFlags.Static | BindingFlags.NonPublic);
    
            public IQueryable CreateQuery(Expression expression)
            {
                // We cheat a little: too much complex to call to call the 
                // nongeneric CreateQuery. We call the CreateQuery<>.
                Type type = expression.Type;
                Type element = GetIQueryableTypeArgument(type);
    
                MethodInfo method = CreateQueryImplMethod.MakeGenericMethod(element);
                return (IQueryable)method.Invoke(this, new[] { expression });
            }
    
            protected IQueryable<TElement> CreateQueryImpl<TElement>(Expression expression)
            {
                Expression expression2 = Manipulator != null ? Manipulator(expression) : expression;
    
                IQueryable<TElement> query = BaseQueryProvider.CreateQuery<TElement>(expression2);
                IQueryProvider provider = query.Provider;
                ProxyDbProvider proxy = provider == BaseQueryProvider ? this : new ProxyDbProvider(provider, Manipulator);
    
                return new ProxyQueryable<TElement>(proxy, query);
            }
    
            public TResult Execute<TResult>(Expression expression)
            {
                Expression expression2 = Manipulator != null ? Manipulator(expression) : expression;
                return BaseQueryProvider.Execute<TResult>(expression2);
            }
    
            public object Execute(Expression expression)
            {
                Expression expression2 = Manipulator != null ? Manipulator(expression) : expression;
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
        }
    
        public class ProxyQueryable<TElement> : IOrderedQueryable<TElement>, IQueryable<TElement>, IEnumerable<TElement>, IOrderedQueryable, IQueryable, IEnumerable
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
        }
    
        public class MyExpressionManipulator : ExpressionVisitor
        {
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (node.Method.DeclaringType == typeof(Queryable) && node.Method.Name == "Where" && node.Arguments.Count == 2)
                {
                    // Transforms all the .Where(x => something) in
                    // .Where(x => something && something)
                    if (node.Arguments[1].NodeType == ExpressionType.Quote)
                    {
                        UnaryExpression argument1 = (UnaryExpression)node.Arguments[1]; // Expression.Quote
    
                        if (argument1.Operand.NodeType == ExpressionType.Lambda)
                        {
                            LambdaExpression argument1lambda = (LambdaExpression)argument1.Operand;
    
                            // Important: at each step you'll reevalute the
                            // full expression! Try to not replace twice
                            // the expression!
                            // So if you have a query like:
                            // var res = ctx.Where(x => true).Where(x => true).Select(x => 1)
                            // the first time you'll visit
                            //  ctx.Where(x => true)
                            // and you'll obtain
                            //  ctx.Where(x => true && true)
                            // the second time you'll visit
                            //  ctx.Where(x => true && true).Where(x => true)
                            // and you want to obtain
                            //  ctx.Where(x => true && true).Where(x => true && true)
                            // and not
                            //  ctx.Where(x => (true && true) && (true && true)).Where(x => true && true)
                            if (argument1lambda.Body.NodeType != ExpressionType.AndAlso)
                            {
                                var arguments = new Expression[node.Arguments.Count];
                                node.Arguments.CopyTo(arguments, 0);
    
                                arguments[1] = Expression.Quote(Expression.Lambda(Expression.AndAlso(argument1lambda.Body, argument1lambda.Body), argument1lambda.Parameters));
                                MethodCallExpression node2 = Expression.Call(node.Object, node.Method, arguments);
                                node = node2;
                            }
                        }
                    }
                }
    
                return base.VisitMethodCall(node);
            }
        }
    }
