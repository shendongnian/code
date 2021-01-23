    void Main()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<QueryObjectCreator>()
            .As<ICustomObjectCreator<IQuery>>()
            .InstancePerLifetimeScope();
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
        
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            JsonObjectContract contract = base.CreateObjectContract(objectType);
            
            var customObjectCreatorType = typeof(ICustomObjectCreator<>).MakeGenericType(objectType);
            if (!_container.IsRegistered(customObjectCreatorType))
                return contract;
                
            var customObjectCreator = (ICustomObjectCreator) _container.Resolve(customObjectCreatorType);
            
            // I don't know how you want to obtain the string which shall be passed to CreateObject
            contract.DefaultCreator = () => customObjectCreator.CreateObject("XYZ");
            return contract;
        }
    }
    public interface ICustomObjectCreator
    {
        object CreateObject(string type);
    }
    public interface ICustomObjectCreator<out T> : ICustomObjectCreator
    {
        T Create(string type);
    }
    public abstract class ObjectCreatorBase<T> : ICustomObjectCreator<T>
    {
        public object CreateObject(string type)
        {
            return Create(type);
        }
        public abstract T Create(string type);
    }
    public class QueryObjectCreator : ObjectCreatorBase<IQuery>
    {
        public override IQuery Create(string type)
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
