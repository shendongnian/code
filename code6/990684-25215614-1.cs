    class A {
       public void b() { ... }
    }
    class B {
       A m;
       public void b() { m.b(); }
    }
