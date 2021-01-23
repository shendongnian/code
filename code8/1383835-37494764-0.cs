     class Program
    {
        static void Main()
        {
            
            Type type= typeof (GenericClass<>).MakeGenericType(typeof(int));
            var method = type.GetMethod("TestMethod");
            var instance = Activator.CreateInstance(type);
            method.Invoke(instance, null); 
        }
    }
    public class GenericClass<T> where T : struct // These parameters can be anything
    {
        public T TestMethod()
        {
            T a = new T();
            return a; 
        }
    }
