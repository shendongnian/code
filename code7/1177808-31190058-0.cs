    interface MyInterface
    {
       void MyMethod();
    }
    class A : MyInterface  // Implicit implementation
    {
       public void MyMethod () { ... }
    }
    
    class B: MyInterface   // Explicit implementation
    {
       void MyInterface.MyMethod () { ... }
    }
