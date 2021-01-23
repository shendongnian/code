    using System;
    
    namespace ConsoleApplication11
    {
        class Program
        {
            static void Main(string[] args)
            {
                var str = EmptyArray<string>.Instance;
                var intTest = EmptyArray<int>.Instance;
                var intTest1 = EmptyArray<int>.Instance;  
                var str1 = EmptyArray<string>.Instance;
                Console.WriteLine(str.GetType());
                Console.WriteLine(intTest.GetType());
                if (ReferenceEquals(str,str1))
                {
                    Console.WriteLine("References are equals");
                }
                if (ReferenceEquals(intTest,intTest1)) ;            
                {
                    Console.WriteLine("References are equals");
                }
                
            }
        }
    
        public static class EmptyArray<T>
        {
            public static readonly T[] Instance;
    
            static EmptyArray()
            {
                Instance =  new T[0];
            }
        }
    }
