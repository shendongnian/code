    public class ParameterFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
            {
                return;
            }
            foreach (var parameter in operation.parameters
                .Where(x => x.@in == "query" && x.name.Contains(".")))
            {
                parameter.name = Regex.Replace(parameter.name,
                    @"^ # Match start of string
                    .*? # Lazily match any character, trying to stop when the next condition becomes true
                    \.  # Match the dot", "", RegexOptions.IgnorePatternWhitespace);
            }
        }
    }
