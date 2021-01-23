    abstract class Foo
    {
       protected abstract void PostA();   
    
       [SomeAttributeToMarkTheMethodToFireTheWarning]
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
