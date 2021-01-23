    void Main()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<QueryObjectCreator>()
            .As<ICustomObjectCreator<IQuery>>()
            .InstancePerLifetimeScope();
        
        builder.RegisterGeneric(typeof(CustomConverter<>)).AsSelf().InstancePerLifetimeScope();
        var container = builder.Build();
        Func<JsonSerializerSettings> settingsFactory = () =>
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new AutofacContractResolver(container);
            
            return settings;
        };
        
        JsonConvert.DefaultSettings = settingsFactory;
        var myObject = new MyObject { Query = new Query(42) };
        
        var json = JsonConvert.SerializeObject(myObject);
        
        myObject = JsonConvert.DeserializeObject<MyObject>(json);
        Console.WriteLine(myObject.Query.MyProperty);
    }
    // Define other methods and classes here
    public class AutofacContractResolver : DefaultContractResolver
    {
        private readonly IContainer _container;
        public AutofacContractResolver(IContainer container)
        {
            _container = container;
        }
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            var customObjectCreatorType = typeof(ICustomObjectCreator<>).MakeGenericType(objectType);
            if (!_container.IsRegistered(customObjectCreatorType))
                return base.ResolveContractConverter(objectType);
                
            var customConverterType = typeof(CustomConverter<>).MakeGenericType(objectType);
            return (JsonConverter) _container.Resolve(customConverterType);
        }
    }
    public class CustomConverter<T> : JsonConverter
    {
        // This should be created via AutoFac
        public ICustomObjectCreator<T> ObjectCreator { get; }
        // This default constructr always gets called
        public CustomConverter() { }
        // I want to call this constructor
        public CustomConverter(ICustomObjectCreator<T> objectCreator)
        {
            Console.WriteLine("Constructor called");
            ObjectCreator = objectCreator;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            // Load JObject from stream 
            var jObject = JObject.Load(reader);
            // Create target object based on JObject 
            var target = Create(objectType, jObject);
            // Populate the object properties 
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
        protected T Create(Type objectType, JObject jObject)
        {
            var type = jObject.GetValue("type", StringComparison.OrdinalIgnoreCase)?.Value<string>();
            return ObjectCreator.Create(type);
        }
    }
    public interface ICustomObjectCreator<out T> 
    {
        T Create(string type);
    }
    public class QueryObjectCreator : ICustomObjectCreator<IQuery>
    {
        public IQuery Create(string type)
        {
            Console.WriteLine("Create called");
            
            // ... some logic to create a concrete object
            var concreteObject = new Query();
            return (IQuery)concreteObject;
        }
    }
    public interface IQuery
    {
        int MyProperty { get; set; }
    }
    public class Query : IQuery
    {
        public int MyProperty { get; set; }
        
        public Query()
        {
        }
        
        public Query(int myProperty)
        {
            MyProperty = myProperty;
        }
    }
    public class MyObject
    {
        public IQuery Query { get; set; }
    }
