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
       public override void PostA()
       {
          
       }
    }
