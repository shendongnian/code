    SwaggerDocsConfig configuration;
    .....
    configuration.DocumentFilter<PolymorphismDocumentFilter<ReadingEntry>>();
    configuration.SchemaFilter<PolymorphismSchemaFilter<ReadingEntry>>();
    .....
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
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            if (!derivedTypes.Value.Contains(type)) return;
            var clonedSchema = new Schema
                                    {
                                        properties = schema.properties,
                                        type = schema.type,
                                        required = schema.required
                                    };
            //schemaRegistry.Definitions[typeof(T).Name]; does not work correctly in SwashBuckle
            var parentSchema = new Schema { @ref = "#/definitions/" + typeof(T).Name };   
            schema.allOf = new List<Schema> { parentSchema, clonedSchema };
            //reset properties for they are included in allOf, should be null but code does not handle it
            schema.properties = new Dictionary<string, Schema>();
        }
    }
    public class PolymorphismDocumentFilter<T> : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, System.Web.Http.Description.IApiExplorer apiExplorer)
        {
            RegisterSubClasses(schemaRegistry, typeof(T));
        }
        private static void RegisterSubClasses(SchemaRegistry schemaRegistry, Type abstractType)
        {
            const string discriminatorName = "discriminator";
            var parentSchema = schemaRegistry.Definitions[SchemaIdProvider.GetSchemaId(abstractType)];
            //set up a discriminator property (it must be required)
            parentSchema.discriminator = discriminatorName;
            parentSchema.required = new List<string> { discriminatorName };
            if (!parentSchema.properties.ContainsKey(discriminatorName))
                parentSchema.properties.Add(discriminatorName, new Schema { type = "string" });
            //register all subclasses
            var derivedTypes = abstractType.Assembly
                                           .GetTypes()
                                           .Where(x => abstractType != x && abstractType.IsAssignableFrom(x));
            foreach (var item in derivedTypes)
                schemaRegistry.GetOrRegister(item);
        }
    }
