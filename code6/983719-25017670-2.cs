    using System;
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
                int[][] res = new int[2][];
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                for (var i = 0; i < 1000000000; i++)
                    res[i % 2] = T1<int>.Instance;
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                sw.Restart();
                for (var i = 0; i < 1000000000; i++)
                    res[i % 2] = T2<int>.Instance;
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                sw.Restart();
                for (var i = 0; i < 1000000000; i++)
                    res[i % 2] = T3<int>.Instance;
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                sw.Restart();
                for (var i = 0; i < 1000000000; i++)
                    res[i % 2] = T4<int>.Instance;
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                sw.Restart();
                for (var i = 0; i < 1000000; i++)
                    res[i % 2] = new int[0];
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                Console.WriteLine(res[0]);
                Console.WriteLine(res[1]);
            }
        }
    }
