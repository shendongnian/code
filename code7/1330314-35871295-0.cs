    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main()
            {
                var theType = Type.GetType("ConsoleApplication.TestClass");
                var argumentType = typeof(int);
                ConstructorInfo ctor = theType.GetConstructor(new Type[] { argumentType });
                object instance = ctor.Invoke(new object[] { Convert.ChangeType(new ImplicitTest(5.1), argumentType) });
                Console.ReadLine();
            }
        }
        public class TestClass
        {
            public int Val { get; set; }
            public TestClass(int Val)
            {
                this.Val = Val;
            }
        }
        public class ImplicitTest : IConvertible
        {
            public double Val { get; set; }
            public ImplicitTest(double Val)
            {
                this.Val = Val;
            }
            public static implicit operator int(ImplicitTest d)
            {
                return (int)d.Val;
            }
            public int ToInt32(IFormatProvider provider)
            {
                return (int)this;
            }
            //Other methods of IConvertible
        }
    }
