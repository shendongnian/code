    public interface IBaseClassExtension
    {
        public string ExtensionProperty { get; set; }
        public int ExtensionProperty2 { get; set; }
    }
    public class BaseClass
    {
        Dictionary<string, object> propertys = new Dictionary<string, object>();
        public void Add(string name, object instance)
        {
            propertys[name] = instance;
        }
        public T Get<T>(string name)
        {
            return (T)propertys[name];
        }
        public void Test()
        {
            Add(nameof(IBaseClassExtension.ExtensionProperty), "HelloWorld");
            string helloWorld = Get<string>(nameof(IBaseClassExtension.ExtensionProperty));
        }
    }
