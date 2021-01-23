        public void Apply(Schema model, SchemaFilterContext context)
        {
            ...
            // Prepare a dictionary of inherited properties
            var inheritedProperties = context.SystemType.GetProperties()
                .Where(x => x.DeclaringType != context.SystemType)
                .ToDictionary(x => x.Name, StringComparer.OrdinalIgnoreCase);
            var clonedSchema = new Schema
            {
                // Exclude inherited properties. If not excluded, 
                // they would have appeared twice in nswag-generated typescript definition
                Properties =
                    model.Properties.Where(x => !inheritedProperties.ContainsKey(x.Key))
                        .ToDictionary(x => x.Key, x => x.Value),
                Type = model.Type,
                Required = model.Required
            };
            ...
        }
  
