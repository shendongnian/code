    abstract class RecursiveProvider : JSchemaGenerationProvider {
        public string SkipType { get; set; }
        public override JSchema GetSchema(JSchemaTypeGenerationContext context) {
            var type = context.ObjectType;
            JSchema schema = null;
    
            var generator = new JSchemaGenerator();
    
            Console.WriteLine(type.Name);
    
            var isObject = type.Namespace != "System";
    
            if (isObject) {
                if (SkipType == type.Name)
                    return null;
    
                this.SkipType = type.Name;
                generator.GenerationProviders.Add(this);
            }
    
            schema = generator.Generate(type);
            return ModifySchema(schema, context);
        }
    
        public abstract JSchema ModifySchema(JSchema schema, JSchemaTypeGenerationContext context);
    
    }
    
    class PropertyProvider : RecursiveProvider {
        public override JSchema ModifySchema(JSchema schema, JSchemaTypeGenerationContext context) {
            schema.Title = "My Title";
            return schema;
        }
    }
