    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
    
            public class Wrapper<T>
            {
                public T Data { get; set; }
                public string[] Metadata
                {
                    get; set;
                }
    
            }
    
            public class SomeOtherClass
            {
                public object WrappedData { get; set; }
            }
    
    
            static void Main(string[] args)
            {
                var wrappedData = new Wrapper<int> { Data = 3 };
                var someObject = new SomeOtherClass { WrappedData = wrappedData };
    
                dynamic d = someObject.WrappedData;
                Console.WriteLine(d.Data);
               
            }
        }
    }
