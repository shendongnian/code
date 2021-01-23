    public class Foo
    {
    ...
            public static void AddPredefinedType(Type type)
            {
                ExpressionParser.predefinedTypes = ExpressionParser.predefinedTypes.Union(new[] { type }).ToArray();
                ExpressionParser.CreateKeywords();
            }
    }
