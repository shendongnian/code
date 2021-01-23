    abstract class Parent : ICanDoSomethingElse
    {
       ...
       public abstract void DoIt(string thingToDo);
    }
    class Child : Parent, ICanDoSomethingElse
    {
       ...
       public override void DoIt(string thingToDo)
       {
          // Implementation
       }
    }
