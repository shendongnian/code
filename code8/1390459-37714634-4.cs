    public class ParameterFilter : IOperationFilter
    {
        private const string Pattern = @"^ # Match start of string
                    .*? # Lazily match any character, trying to stop when the next condition becomes true
                    \.  # Match the dot";
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
            {
                return;
            }
            foreach (var parameter in operation.parameters
                .Where(x => x.@in == "query" && x.name.Contains(".")))
            {
                parameter.name = Regex.Replace(
                    parameter.name,
                    Pattern, 
                    string.Empty, 
                    RegexOptions.IgnorePatternWhitespace);
            }
        }
    }
