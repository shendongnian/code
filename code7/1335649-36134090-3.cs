    public static class AutoExtensions {
        public static IMappingExpression Ignore(this IMappingExpression expression, Func<PropertyInfo, bool> filter) {
            foreach (var propertyName in expression
                .TypeMap
                .SourceType
                .GetProperties()
                .Where(filter)
                .Select(x=>x.Name))
            {
                expression.ForMember(propertyName, behaviour => behaviour.Ignore());
            }
            return expression;
        }
    }
