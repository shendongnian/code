    class A {
        public int a = 5;
        
        public static bool operator==(A a, B b) {
            return a.a == b.b;
        }
        public static bool operator!=(A a, B b) {
            return !(a == b);
        }
    }
    class B {
        public int b = 5;
    }
    // ...
    Console.WriteLine(new A() == new B()); // "true"
