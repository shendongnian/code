        public static Data BuildData<T>(Expression<Func<T>> e, appDetailCategory category)
        {
            var member = (MemberExpression)e.Body;
            var name = member.Member.Name;
            var value = Expression.Lambda<Func<string>>(member).Compile()();
            return new Data
            {
                Attribute = name,
                Value = value
            };
        }
