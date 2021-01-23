    abstract class Foo
    {
       protected abstract void PostA();  
       public void A() { 
          ... 
          PostA();
       }
    }
    
    
    class Bar : Foo
    {
       protected override void PostA()
       {
          
       }
    }
    //method signature remains the same:
    Bar.A();
