    class QueryParameterFilter : IOperationFilter
        {
            void IOperationFilter.Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {
                if (apiDescription.ResponseDescription.ResponseType != null && apiDescription.ResponseDescription.ResponseType.Name.Contains("PagedResult"))
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>()
                    {
                        { "$top", "The max number of records"},
                        { "$skip", "The number of records to skip"},
                        { "$filter", "A function that must evaluate to true for a record to be returned"},
                        { "$select", "Specifies a subset of properties to return"},
                        { "$orderby", "Determines what values are used to order a collection of records"}
                    };
                    operation.parameters = new List<Parameter>();
                    foreach (var pair in parameters)
                    {
                        operation.parameters.Add(new Parameter
                        {
                            name = pair.Key,
                            required = false,
                            type = "string",
                            @in = "query",
                            description = pair.Value
                        });
                    }
                }
            }
