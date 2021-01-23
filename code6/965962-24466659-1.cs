    class Program
    {
        public class Model { }
        public class ModelB : Model { }
        public class Api<T> where T : Model
        {
            public List<T> CallGenericMethod()
            {
                return new List<T>();
            }
        }
        public class ApiB: Api<ModelB> { }
        public static string DoSomething<T>(Api<T> a) where T : Model
        {
            var b = a.CallGenericMethod();
            return b.GetType().ToString();
        }
        static void Main(string[] args)
        {
            ApiB a = new ApiB();
            Console.WriteLine(DoSomething(a));
        }
    }
