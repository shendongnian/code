    public class IgnorePrefixParamsNameBeforeDot : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters != null)
            {
                foreach (Parameter param in operation.parameters.Where(p => p.name.Contains('.')))
                {
                    param.name = param.name.SplitWithoutEmpty('.').Last();
                }
            }
        }
    }
