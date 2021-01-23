    public class MyJsonSchemaGenerator : JsonSchemaGenerator
    {
        public MyJsonSchemaGenerator(JsonSchemaGeneratorSettings settings)
            : base(settings)
        {
        }
        protected override void GenerateObject<TSchemaType>(Type type, TSchemaType schema, JsonSchema4 rootSchema,
            ISchemaDefinitionAppender schemaDefinitionAppender, ISchemaResolver schemaResolver)
        {
            base.GenerateObject(type, schema, rootSchema, schemaDefinitionAppender, schemaResolver);
            schema.AllowAdditionalProperties = true;
        }
    }
