    class X : A, B {
        public void MethodX() {...}
        public void MethodY() {...}
    }
    public static void Main(string[] args) {
        var x = new X();
        x.SomeMethodFromA();
        x.MethodX(); // Calls method from X
        x.MethodY(); // Calls method from X
        x.MethodZ(); // Calls method from ExtensionsB
    }
