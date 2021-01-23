    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace Zoltan
    {
               
        public class SomeClass<T>
        {
            private static readonly Func<T,T> FALL_BACK_HANDLER = a => a; //or what have you
            
            private readonly Func<T,T> m_handler;
                  
            public SomeClass(Func<T,T> handler)
            {
                m_handler = handler;
            }
            
            public SomeClass()
            {
                m_handler = DefaultHandler.For<T>() ?? FALL_BACK_HANDLER;
            }
            
            public void DoSomeStuff(T input)
            {
                T result = m_handler(input);
                Console.WriteLine(result);
            }
        }
        
        public static class DefaultHandler
        {
            public static Func<T,T> For<T>()
            {
                return TypeAware<T>.Default;
            }
            
            private static class TypeAware<T>
            {
                private static readonly Func<T,T> DEFAULT;
                static TypeAware()
                {
                    var type = typeof(T);
                    if (type == typeof(string))
                    {
                        DEFAULT = a => DefaultHandler.StringHandler((dynamic) a);
                    }
                    else if (type == typeof(int))
                    {
                        DEFAULT = a => DefaultHandler.IntHandler((dynamic) a);
                    }
                    else
                    {
                        DEFAULT = null;
                    }
                }
                                
                public static Func<T,T> Default { get { return DEFAULT; } }
            }
            
            public static string StringHandler(string a)
            {
                return a + " The default handler does some stuff!";
            }
            
            public static int IntHandler(int a)
            {
                return a + 2;
            }
        }
    }
