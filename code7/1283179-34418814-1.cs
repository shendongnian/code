    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Net;
    
    namespace Rextester
    {
        public class Program
        {
            public class LazyWithoutExceptionCaching<T>
            {
                private readonly Func<T> _valueFactory;
                private Lazy<T> _lazy;
                 
                public LazyWithoutExceptionCaching(Func<T> valueFactory)
                {
                    _valueFactory = valueFactory;
                    _lazy = new Lazy<T>(valueFactory);
                }
        
                public T Value
                {
                    get
                    {
                        try
                        {
                            return _lazy.Value;
                        }
                        catch (Exception)
                        {
                            _lazy = new Lazy<T>(_valueFactory);
                            throw;
                        }
                    }
                }
            }
            
            public class LightsaberProvider
            {
                private static int _firstTime = 1;
    
                public LightsaberProvider()
                {
                    Console.WriteLine("LightsaberProvider ctor");
                }
    
                public string GetFor(string jedi)
                {
    				Console.WriteLine("LightsaberProvider.GetFor jedi: {0}", jedi);
    
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    if (jedi == "2" && 1 == Interlocked.Exchange(ref _firstTime, 0))
                    {
                        throw new Exception("Dark side happened...");
                    }
    
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    return string.Format("Lightsaver for: {0}", jedi);
                }
            }
    
            public class LightsabersCache
            {
                private readonly LightsaberProvider _lightsaberProvider;
                private readonly ConcurrentDictionary<string, LazyWithoutExceptionCaching<string>> _producedLightsabers;
    
                public LightsabersCache(LightsaberProvider lightsaberProvider)
                {
                    _lightsaberProvider = lightsaberProvider;
                    _producedLightsabers = new ConcurrentDictionary<string, LazyWithoutExceptionCaching<string>>();
                }
    
                public string GetLightsaber(string jedi)
                {
                    LazyWithoutExceptionCaching<string> result;
                    if (!_producedLightsabers.TryGetValue(jedi, out result))
                    {
                        result = _producedLightsabers.GetOrAdd(jedi, key => new LazyWithoutExceptionCaching<string>(() =>
                        {
                            Console.WriteLine("Lazy Enter");
                            var light = _lightsaberProvider.GetFor(jedi);
                            Console.WriteLine("Lightsaber produced");
                            return light;
                        }));
                    }
                    return result.Value;
                }
            }
            
            public static void Main(string[] args)
            {
                Test();
                Console.WriteLine("Maximum 1 'Dark side happened...' strings on the console there should be. No more, no less.");
                Console.WriteLine("Maximum 5 lightsabers produced should be. No more, no less.");
            }
    
            private static void Test()
            {
                var cache = new LightsabersCache(new LightsaberProvider());
    
                Parallel.For(0, 15, t =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            var result = cache.GetLightsaber((t % 5).ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Thread.Sleep(25);
                    }
                });
            }
        }
    }
