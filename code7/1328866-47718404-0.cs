    public class RequiredParameterOverrideOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            // Get all SwaggerParameterAttributes on the method
            var attributes = apiDescription.ActionDescriptor.GetCustomAttributes<SwaggerParameterAttribute>();
            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }
            // For each attribute found, find the operation parameter (this is where Swagger looks to generate the Swagger doc)
            // Override the required fields based on the attribute's required field
            foreach (var attribute in attributes)
            {
                var referencingOperationParameter = operation.parameters.FirstOrDefault(p => p.name == attribute.Name);
                if (referencingOperationParameter != null)
                {
                    referencingOperationParameter.required = attribute.Required;
                }
            }
        }
    }
