    public static class ValidationHelper
    {
        public static IEnumerable<string> FindEmptyProperties<T>(T target, params Expression<Func<T, string>>[] propertySelectors)
        {
            foreach (var propertySelector in propertySelectors)
            {
                if (string.IsNullOrEmpty(propertySelector.Compile()(target)))
                {
                    var memberExpr = propertySelector.Body as MemberExpression;
                    yield return memberExpr.Member.Name;
                }
            }
        }
    }
