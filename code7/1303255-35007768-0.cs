    class Parent
    {
      public void foo(){ Console.WriteLine("Parent foo"); }
      public virtual void foo1() {Console.WriteLine("Parent foo1");}
    }
    
    class Child : Parent // class Child extends Parent
    {
      public void foo() { Console.WriteLine("Child foo"); }
      public override void foo1(){ Console.WriteLine("Child foo1"); }
    }
    
      public static void Main()
      {
         Child child = new Child();
         Parent parent = new Parent();
         parent = child;// is perfectly valid.
         //child = parent;// is not valid. Error
    
         parent.foo();
         parent.foo1();
      }
