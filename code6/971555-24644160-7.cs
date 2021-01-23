    public static class AnonExtensions
    {
        public static TSource SetValues<TSource, TValue>(
            this TSource source,
            Expression<Func<TSource, TValue>> setter)
        {
            var copierExpr = new Copier<TSource, TValue>().Rewrite(setter);
            var copier = copierExpr.Compile();
            return copier(source);
        }
        
        public static IEnumerable<TSource> UpdateValues<TSource, TValue>(
            this IEnumerable<TSource> source,
            Expression<Func<TSource, TValue>> setter)
        {
            var copierExpr = new Copier<TSource, TValue>().Rewrite(setter);
            var copier = copierExpr.Compile();
            return source.Select(copier);
        }
        
        public static IQueryable<TSource> UpdateValues<TSource, TValue>(
            this IQueryable<TSource> source,
            Expression<Func<TSource, TValue>> setter)
        {
            var copierExpr = new Copier<TSource, TValue>().Rewrite(setter);
            return source.Select(copierExpr);
        }
        
        private class Copier<TSource, TValue> : ExpressionVisitor
        {
            private readonly ParameterExpression param =
                Expression.Parameter(typeof(TSource));
            public Expression<Func<TSource, TSource>> Rewrite(
                Expression<Func<TSource, TValue>> setter)
            {
                var newExpr = new SubstitutionVisitor(
                    setter.Parameters.Single(), param).Visit(setter.Body);
                var body = this.Visit(newExpr);
                return Expression.Lambda<Func<TSource, TSource>>(body, param);
            }
            
            protected override Expression VisitNew(NewExpression node)
            {
                var type = typeof(TSource);
                var ctor = type.GetConstructors().Single();
                var arguments = new List<Expression>();
                var members = new List<MemberInfo>();
                var propMap = GetPropertyMap(node);
                foreach (var prop in type.GetProperties())
                {
                    Expression arg;
                    if (!propMap.TryGetValue(prop.Name, out arg))
                        arg = Expression.Property(param, prop);
                    arguments.Add(arg);
                    members.Add(prop);
                }
                return Expression.New(ctor, arguments, members);
            }
            
            private Dictionary<string, Expression> GetPropertyMap(
                NewExpression node)
            {
                return node.Members.Zip(node.Arguments, (m, a) => new { m, a })
                    .ToDictionary(x => x.m.Name, x => x.a);
            }
        }
        
        private class SubstitutionVisitor : ExpressionVisitor
        {
            private Expression oldValue, newValue;
            public SubstitutionVisitor(Expression oldValue, Expression newValue)
            { this.oldValue = oldValue; this.newValue = newValue; }
            
            public override Expression Visit(Expression node)
            {
                return node == oldValue ? newValue : base.Visit(node);
            }
        }
    }
