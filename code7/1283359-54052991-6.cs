        public void Apply(Schema model, SchemaFilterContext context)
        {
            if (!derivedTypes.Value.Contains(context.SystemType))
            {
                return;
            }
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
            // Use the BaseType name for parentSchema instead of typeof(T), 
            // because we could have more abstract classes in the hierarchy
            var parentSchema = new Schema
            {
                Ref = "#/definitions/" + (context.SystemType.BaseType?.Name ?? typeof(T).Name)
            };
            model.AllOf = new List<Schema> { parentSchema, clonedSchema };
            // reset properties for they are included in allOf, should be null but code does not handle it
            model.Properties = new Dictionary<string, Schema>();
        }
