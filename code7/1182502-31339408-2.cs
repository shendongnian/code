    // don't use such naming in production code
    public class Foo
    {
        public void DoWork1()
        {
            // imitating hard computations
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }
        
        public void DoWork2(int param1) 
        {
            // imitating hard computations
            Thread.Sleep(param1);
        }
    }
    public static class Program
    {
        public static void Main()
        {
            var foo = new Foo();
            // signature of foo.DoWork1 is suitable for Invoke.Measure, 
            //so you can use it as MethodGroup
            var time1 = Invoke.Measure(foo.DoWork1);
            Console.WriteLine("Time for 'DoWork1' is {0}s", time1.TotalSeconds);
            // signature of foo.DoWork2 is not suitable for Invoke.Measure,   
            // so you have to call it inside additional lambda 
            var time2 = Invoke.Measure(() => foo.DoWork2(42));
            Console.WriteLine("Time for 'DoWork2' is {0}s", time2.TotalSeconds);
        }
    }
