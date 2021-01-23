    public class A
    {
      public int value {get; set;} //want to try beetween 0 and 5
      public bool foo {get; set;}
      public bool bar {get; set;}
      public bool boo {get; set;}
    
      public A()
      {
         // initialize value, foo, bar, boo with desired default / random here
      }
    }
    
    var myList = new List<A>();
    for (int i=0; i<=24; i++) myLyst.add(new A());
