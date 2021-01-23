    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace BindingExample
    {
        public class SomeBaseClassA
        {
            public override string ToString() => "From SomeBaseClassA";
        }
        public class SpecialisationA : SomeBaseClassA
        {
            public override string ToString() => "From SpecialisationA";
        }
        public class SomeBaseClassB
        {
            public new string ToString() => "From SomeBaseClassB";
        }
        public class SpecialisationB : SomeBaseClassB
        {
            public new string ToString() => "From SpecialisationB";
        }
        class Program
        {
            static void Main(string[] args)
            {
                // First Example
                SomeBaseClassA a1 = new SomeBaseClassA();
                Console.WriteLine(a1);
                SpecialisationA a2 = new SpecialisationA();
                Console.WriteLine(a2);
                SomeBaseClassA a3 = a2;
                Console.WriteLine(a3);
                // Second Example
                SomeBaseClassB b1 = new SomeBaseClassB();
                Console.WriteLine(b1.ToString());
                SpecialisationB b2 = new SpecialisationB();
                Console.WriteLine(b2.ToString());
                SomeBaseClassB b3 = b2;
                Console.WriteLine(b3.ToString());
                Console.ReadLine();
            }
        }
    }
