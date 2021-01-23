    public class MyJsonSchemaGenerator : JsonSchemaGenerator
    {
        public MyJsonSchemaGenerator(JsonSchemaGeneratorSettings settings)
            : base(settings)
        {
        }
        protected override void GenerateObject<TSchemaType>(Type type, TSchemaType schema, ISchemaResolver schemaResolver, ISchemaDefinitionAppender schemaDefinitionAppender)
            where TSchemaType : JsonSchema4, new()
        {
            base.GenerateObject(type, schema, rootSchema, schemaDefinitionAppender, schemaResolver);
            schema.AllowAdditionalProperties = true;
        }
    }
