    using System;
    using System.Threading.Tasks;
    namespace ConsoleSandbox
    {
        class T1<T>
        {
            static volatile T[] _instance;
            public static T[] Instance
            {
                get
                {
                    if (_instance == null) _instance = new T[0];
                    return _instance;
                }
            }
        }
        class T2<T>
        {
            static T[] _instance;
            static object _syncRoot = new object();
            public static T[] Instance
            {
                get
                {
                    if (_instance == null) 
                        lock (_syncRoot)
                            if (_instance == null)
                                _instance = new T[0];
                    return _instance;
                }
            }
        }
        class T3<T>
        {
            static T[] _instance = new T[0];
            public static T[] Instance
            {
                get
                {
                    return _instance;
                }
            }
        }
        class T4<T>
        {
            static T[] _instance;
            public static T[] Instance
            {
                get
                {
                    if (_instance == null)
                        lock (typeof(T4<T>))
                            if (_instance == null)
                                _instance = new T[0];
                    return _instance;
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                int[] t;
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                for (var i = 0; i < 1000000000; i++)
                    t = T1<int>.Instance;
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                sw.Restart();
                for (var i = 0; i < 1000000000; i++)
                    t = T2<int>.Instance;
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                sw.Restart();
                for (var i = 0; i < 1000000000; i++)
                    t = T3<int>.Instance;
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                sw.Restart();
                for (var i = 0; i < 1000000000; i++)
                    t = T4<int>.Instance;
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                sw.Restart();
                for (var i = 0; i < 1000000000; i++)
                    t = new int[0];
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
            }
        }
    }
