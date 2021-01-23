    public class FluentValidationRules : ISchemaFilter
        {
            public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
            {
                var validator = new Customer(); //Your fluent validator class
    
                schema.required = new List<string>();
    
                var validatorDescriptor = validator.CreateDescriptor();
    
                foreach (var key in schema.properties.Keys)
                {
                    foreach (var validatorType in validatorDescriptor.GetValidatorsForMember(key))
                    {
                        if (validatorType is NotEmptyValidator)
                        {
                            schema.required.Add(key);
                        }
                    }
                }
            }
        }
