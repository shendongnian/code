    public class Tester
    {
        private static readonly MethodInfo _run2Method = typeof(Tester).GetMethod("Run2");
        public void Run1<T>()
        {
            if (typeof(IEnumerable).IsAssignableFrom(typeof(T)))
                Run2AsIEnumerable<T>();
            else
                Console.WriteLine("Run1 for {0}", typeof(T));
        }
        public void Run2<T>() where T : IEnumerable
        {
            Console.WriteLine("Run2 for {0}", typeof(T));
        }
        private void Run2AsIEnumerable<T>()
        {
            Console.WriteLine("Detour to run2 for {0}", typeof(T));
            var method = _run2Method.MakeGenericMethod(typeof(T));
            method.Invoke(this, new object[0]);
        }
    }
