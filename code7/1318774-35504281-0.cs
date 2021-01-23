    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ParallelMethodsCounter
    {
        class Program
        {
            public static int _parallelCounter = 0;
            public static int _maxParallelExecutionsCount = 0;
    
            static void Main(string[] args)
            {
                Parallel.For(0, 10, i => DoSomething(i));
                Console.WriteLine("MAX PARALLEL EXECUTIONS: {0}", _maxParallelExecutionsCount);
            }
    
            public static void DoSomething(int par)
            {
                int currentParallelExecutionsCount = Interlocked.Increment(ref _parallelCounter);
                InterlockedExchangeIfGreaterThan(ref _maxParallelExecutionsCount, currentParallelExecutionsCount, currentParallelExecutionsCount);
                Console.WriteLine("Current parallel executions: {0}", currentParallelExecutionsCount);
                try
                {
                    //Do your work here
                }
                finally
                {
                    Interlocked.Decrement(ref _parallelCounter);
                }
            }
    
            public static bool InterlockedExchangeIfGreaterThan(ref int location, int comparison, int newValue)
            {
                int initialValue;
                do
                {
                    initialValue = location;
                    if (initialValue >= comparison) return false;
                }
                while (Interlocked.CompareExchange(ref location, newValue, initialValue) != initialValue);
                return true;
            }
        }
    }
