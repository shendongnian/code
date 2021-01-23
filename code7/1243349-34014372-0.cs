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
        /// <summary>
        /// General test method for erasable code
        /// </summary>
        public static void TestGeneral()
        {
            A1 a1 = new A1();
            B1 b1 = new B1();
            b1.A_obj = a1;
            A2 a2 = new A2();
            B2 b2 = new B2();
            b2.A_obj = a2;
            // The following line fails: cannot implicitly convert A1 to A2
            //b2.A_obj = a1;
        }
