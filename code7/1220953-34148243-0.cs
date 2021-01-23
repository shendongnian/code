    public class ApplyResponseTypeAttributes : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (apiDescription.GetControllerAndActionAttributes<SwaggerResponseRemoveDefaultsAttribute>().Any())
            {
                operation.responses.Clear();
            }
            var responseAttributes = apiDescription.GetControllerAndActionAttributes<ResponseTypeAttribute>()
                .OrderBy(attr => attr.ResponseType.Name);
            foreach (var attr in responseAttributes)
            {
                // assume 200
                var statusCode = "200";
                operation.responses[statusCode] = new Response
                {
                    description = InferDescriptionFrom(statusCode),
                    schema = (attr.ResponseType != null) ? schemaRegistry.GetOrRegister(attr.ResponseType) : null
                };
            }
        }
        private string InferDescriptionFrom(string statusCode)
        {
            HttpStatusCode enumValue;
            if (Enum.TryParse(statusCode, true, out enumValue))
            {
                return enumValue.ToString();
            }
            return null;
        }
    }
