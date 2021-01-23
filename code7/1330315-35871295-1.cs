    using System;
    using System.Reflection;
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main()
            {
                var theType = Type.GetType("ConsoleApplication.TestClass");
                ConstructorInfo ctor = theType.GetConstructors()[0];
                var argumentType = ctor.GetParameters()[0].ParameterType;
                object contructorArgument = new ImplicitTest(5.1);
                object instance = ctor.Invoke(new object[] { Convert.ChangeType(contructorArgument, argumentType) });
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
