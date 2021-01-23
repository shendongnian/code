    class Parent : ICanDoSomethingElse
    {
       ...
       public void DoIt(string thingToDo)
       {
          // Implementation
       }
    }
    class Child : Parent, ICanDoSomethingElse
    {
       ...
       public new void DoIt(string thingToDo)
       {
          // Implementation
       }
    }
