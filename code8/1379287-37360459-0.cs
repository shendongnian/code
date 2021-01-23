    using System;
    
    namespace polymorphismExample {
        public class class1 {
            public virtual string A => "I am Class1.A";
            public         string B => "I am Class1.B";
        }
        public class class2 : class1 {
            public override string A => "I am Class2.A";
        //    public override string B => "I am Class1.B";
            public    new   string B => "I am Class2.B";
        }
        class Program {
            static void Main(string[] args) {
                class1 a1_1 = new class1();
    
                class1 b1_2 = new class2();
                class2 b2_2 = new class2();
    
                Console.WriteLine("{0}: {1}", "a1_1.A", a1_1.A);
                Console.WriteLine("{0}: {1}", "a1_1.A", a1_1.B);
                Console.WriteLine();
    
                Console.WriteLine("{0}: {1}", "b1_2.A", b1_2.A);
                Console.WriteLine("{0}: {1}", "b1_2.A", b1_2.B);
                Console.WriteLine();
    
                Console.WriteLine("{0}: {1}", "b2_2.A", b2_2.A);
                Console.WriteLine("{0}: {1}", "b2_2.A", b2_2.B);
                Console.WriteLine();   
                Console.ReadLine();
            }
        }
    }
