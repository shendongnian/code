    public class O
    {
        private class A { private void Test() {B b = new B(); C c = new C(); }}
    	private class B { private void Test() {A a = new A(); C c = new C(); }}
    	private class C { private void Test() {B b = new B(); A a = new A(); }}
    }
    public class Hacker
    {
        O.A a = new O.A();  // fail
    }
