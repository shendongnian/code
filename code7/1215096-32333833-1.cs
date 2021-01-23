    public static class Extensions
    {
        public static NHibernate.Criterion.Lambda.QueryOverProjectionBuilder<T> GroupByProperty<T>(
            this NHibernate.Criterion.Lambda.QueryOverProjectionBuilder<T> builder, 
            System.Linq.Expressions.Expression<Func<object>> propertyExpression,
            System.Linq.Expressions.Expression<Func<object>> aliasExpression)
        {
            var alias = aliasExpression.ParseProperty();
            var propertyProjection = Projections.Property(propertyExpression);
            var groupProjection = Projections.GroupProperty(propertyProjection);
            var withAliasProjection = Projections.Alias(groupProjection, alias);
            builder.Select(withAliasProjection);
            return builder;
        }
        public static string ParseProperty<TFunc>(this System.Linq.Expressions.Expression<TFunc> expression)
        {
            var body = expression.Body as System.Linq.Expressions.MemberExpression;
            if (body.IsNull())
            {
                return null;
            }
            string propertyName = body.Member.Name;
            ParseParentProperty(body.Expression as System.Linq.Expressions.MemberExpression, ref propertyName);
            // change the   alias.ReferenceName.PropertyName
            // to just            ReferenceName.PropertyName
            var justAPropertyChain = propertyName.Substring(propertyName.IndexOf('.') + 1);
            return justAPropertyChain;
        }
        static void ParseParentProperty(System.Linq.Expressions.MemberExpression expression, ref string propertyName)
        {
            if (expression.IsNull())
            {
                return;
            }
            // Parent.PropertyName
            propertyName = expression.Member.Name + "." + propertyName;
            ParseParentProperty(expression.Expression as System.Linq.Expressions.MemberExpression, ref propertyName);
        }
    }
