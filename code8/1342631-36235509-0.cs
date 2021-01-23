    public class Context {
        public A a;
        public ...other state you want to share...;
        public Context(A a) { this.a = a; ... }
    }
    ...
    A a = new A();
    Context context = new Context(a,...);
    B b = new B(context);
    C c = new C(context);
