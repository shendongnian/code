    public class CsrfDocumentFiler: IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.operationId != "Token_GetToken")
            {
                if (operation.parameters == null)
                    operation.parameters = new List<Parameter>();
                operation.parameters.Add(new Parameter
                {
                    name = "__RequestVerificationToken",
                    @in = "header",
                    type = "string",
                    required = true
                });
            };
        }
    }
