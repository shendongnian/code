        public void Apply(Schema model, SchemaFilterContext context)
        {
            ...
            // Use the BaseType name for parentSchema instead of typeof(T), 
            // because we could have more classes in the hierarchy
            var parentSchema = new Schema
            {
                Ref = "#/definitions/" + (context.SystemType.BaseType?.Name ?? typeof(T).Name)
            };
            ...
        }
