    public class ApplyResponseTypeAttributes : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (apiDescription.GetControllerAndActionAttributes<SwaggerResponseRemoveDefaultsAttribute>().Any())
            {
                operation.responses.Clear();
            }
            // SwaggerResponseAttribute trumps ResponseTypeAttribute
            var swaggerAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerResponseAttribute>();
            if (!swaggerAttributes.Any())
            {
                var responseAttributes = apiDescription.GetControllerAndActionAttributes<ResponseTypeAttribute>().OrderBy(attr => attr.ResponseType.Name);
                foreach (var attr in responseAttributes)
                {
                    const string StatusCode = "200";
                    operation.responses[StatusCode] = new Response
                    {
                        description = InferDescriptionFrom(StatusCode),
                        schema = (attr.ResponseType != null) ? schemaRegistry.GetOrRegister(attr.ResponseType) : null
                    };
                }
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
