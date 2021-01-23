    public class Methods
    {
        public Methods()
        {
            MethodDictionary = new Dictionary<string, Func<ITest, object>>();
            LazyObjects = new Dictionary<string, Lazy<object>>();
        }
        public Dictionary<string, Func<ITest, object>> MethodDictionary { get; private set; }
        public Dictionary<string, Lazy<object>> LazyObjects { get; private set; }
    }
    public class Proxy : DynamicObject
    {
        Methods _methods;
        public Proxy()
        {
            _methods = new Methods();
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _methods.LazyObjects[binder.Name].Value;            
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _methods.MethodDictionary[binder.Name] = (Func<ITest, object>)value;
            _methods.LazyObjects[binder.Name] = new Lazy<object>(() => _methods.MethodDictionary[binder.Name](this.ActLike<ITest>()), true);
            return true;                        
        }
         
    }
    //now you can add new methods by add single method to interface 
    public interface ITest
    {
        object Test1 { get; set; }
        object Test2 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Proxy().ActLike<ITest>();
            x.Test1 = new Func<ITest, object>((y) => "Test1");
            x.Test2 = new Func<ITest, object>((y) => "Test2");
 
            Console.WriteLine(x.Test1);
            Console.WriteLine(x.Test2);
        }
    }
