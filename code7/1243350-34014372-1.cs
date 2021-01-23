        public abstract class A { };
        public class A1 : A { };
        public class A2 : A { };
        public abstract class B<T> where T : A {
            public T A_obj { get; set; }
        };
        public class B1 : B<A1>
        { 
        };
        public class B2 : B<A2>
        {
        };
        public abstract class C<T, U> where T : B<U> where U : A
        {
            public List<T> B_objs { get; private set; }
            public C() {
                B_objs = new List<T>();
            }
        };
        public class C1 : C<B1, A1>
        {
        };
        public class C2 : C<B2, A2>
        {
        };
        public static void Test()
        {
            A1 a1 = new A1();
            B1 b1 = new B1();
            b1.A_obj = a1;
            A2 a2 = new A2();
            B2 b2 = new B2();
            b2.A_obj = a2;
            // The following line fails: cannot implicitly convert A1 to A2
            //b2.A_obj = a1;
            C1 c1 = new C1();
            c1.B_objs.Add(b1);
            // The following fails:
            // c1.B_objs.Add(b2);
        }
