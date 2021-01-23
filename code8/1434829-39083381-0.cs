    public class A
    {
          public A Child{ get; private set; }
          public A(){}
          public A( A child )
          { 
              this.Child = child;
          }
    }
