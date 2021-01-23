    using System;
    using System.Reflection;
    namespace Test
    {
        class Converter
        {
            string Value;
            
            public Converter(string test)
            {
                Value = test;
            }
            protected object StringToValue()
            {
                return Value;
            }
        }
        class myclass
        {
            object Unknown;
            public myclass(object other)
            {
                Unknown = other;
            }
            MethodInfo originalFunction;
            public object StringToValue()
            {
                if (originalFunction == null)
                {
                    originalFunction = Unknown.GetType().GetMethod("StringToValue", BindingFlags.NonPublic | BindingFlags.Instance);
                }
                return originalFunction.Invoke(Unknown, null);
            }
        }
        class Test
        {
            [System.STAThread]
            public static void Main(string[] args)
            {
                Converter unknown = new Converter("TEST");
                myclass mine = new myclass(unknown);
                Console.WriteLine(mine.StringToValue());
                Console.ReadLine();
            }
        }
    }
