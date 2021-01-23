    namespace the_impossible
    {
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            C c = new C();
            b.m1();
            b.m2();
            b.m3();
            c.m4();
            c.m5();
        }
    }
    namespace A_1
    {
        public partial class A
        {
            public  void m1() { }
            public  void m2() { }
            public  void m3() { }
        }
    }
    namespace A_2
    {
        public partial class A
        {
            public void m4() { }
            public void m5() { }
        }
    }
    class B : A_1.A 
    {
        
    }
    class C : A_2.A
    { 
        
    }
    }
