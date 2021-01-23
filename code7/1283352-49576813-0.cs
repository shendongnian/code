    public class PolymorphismSchemaFilter<T> : ISchemaFilter
    {
        private readonly Lazy<HashSet<Type>> derivedTypes = new Lazy<HashSet<Type>>(Init);
        private static HashSet<Type> Init()
        {
            var abstractType = typeof(T);
            var dTypes = abstractType.Assembly
                                     .GetTypes()
                                     .Where(x => abstractType != x && abstractType.IsAssignableFrom(x));
            var result = new HashSet<Type>();
            foreach (var item in dTypes)
                result.Add(item);
            return result;
        }
        public void Apply(Schema model, SchemaFilterContext context)
        {
            if (!derivedTypes.Value.Contains(context.SystemType)) return;
            var clonedSchema = new Schema
            {
                Properties = model.Properties,
                Type = model.Type,
                Required = model.Required
            };
            //schemaRegistry.Definitions[typeof(T).Name]; does not work correctly in SwashBuckle
            var parentSchema = new Schema { Ref = "#/definitions/" + typeof(T).Name };
            model.AllOf = new List<Schema> { parentSchema, clonedSchema };
            //reset properties for they are included in allOf, should be null but code does not handle it
            model.Properties = new Dictionary<string, Schema>();
        }
    }
    public class PolymorphismDocumentFilter<T> : IDocumentFilter
    {
        private static void RegisterSubClasses(ISchemaRegistry schemaRegistry, Type abstractType)
        {
            const string discriminatorName = "discriminator";
            var parentSchema = schemaRegistry.Definitions[abstractType.Name];
            //set up a discriminator property (it must be required)
            parentSchema.Discriminator = discriminatorName;
            parentSchema.Required = new List<string> { discriminatorName };
            if (!parentSchema.Properties.ContainsKey(discriminatorName))
                parentSchema.Properties.Add(discriminatorName, new Schema { Type = "string" });
            //register all subclasses
            var derivedTypes = abstractType.Assembly
                                           .GetTypes()
                                           .Where(x => abstractType != x && abstractType.IsAssignableFrom(x));
            foreach (var item in derivedTypes)
                schemaRegistry.GetOrRegister(item);
        }
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            RegisterSubClasses(context.SchemaRegistry, typeof(T));
        }
    }
