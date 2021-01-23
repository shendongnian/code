    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace BindingExample
    {
        public class SomeBaseClass
        {
            public virtual string CustomString() => "From SomeBaseClass";
        }
        public class FirstSpecialisation : SomeBaseClass
        {
            public override string CustomString() => "From FirstSpecialisation";
        }
    
        public class SecondSpecialisation : SomeBaseClass
        {
            public new string CustomString() => "From SecondSpecialisation";
        }
        class Program
        {
            static void Main(string[] args)
            {
                // Base Example, as expected
                SomeBaseClass a1 = new SomeBaseClass();
                Console.WriteLine(a1.CustomString());
                // First Example, both output the same result
                FirstSpecialisation b1 = new FirstSpecialisation();
                SomeBaseClass b2 = b1;
                Console.WriteLine(b1.CustomString());
                Console.WriteLine(b2.CustomString());
                // Second Example, output different results
                SecondSpecialisation c1 = new SecondSpecialisation();
                SomeBaseClass c2 = c1;
                Console.WriteLine(c1.CustomString());
                Console.WriteLine(c2.CustomString());
                Console.ReadLine();
            }
        }
    }
