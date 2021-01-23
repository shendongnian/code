    public class TestValidator : JsonValidator
    {
        public override bool CanValidate(JSchema schema)
        {
            // we assume every schema has a title/schemaversion in its root object.
            return schema.Title != null || schema.SchemaVersion != null || schema.ExtensionData.ContainsKey("greaterthanfield");
        }
        public override void Validate(JToken value, JsonValidatorContext context)
        {
            // we should ignore the "root token validation"
            if (!context.Schema.ExtensionData.ContainsKey("greaterthanfield"))
                return;
            // value.Parent is hydrated now
        }
    }
