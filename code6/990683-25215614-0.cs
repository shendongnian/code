    class A
    {
       public void b() {...}
    }
    class B
    {
       A m;
       public Action<A> doSomethingWithA;
       public void b() {
          if (doSomethingWithA != null)
             doSomethingWithA(m);
       }
    }
