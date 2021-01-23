    public class Whatever
    {
       private IStage ClassA { get; }
       public Whatever(IStage<YourClassA> yourClassA)
       {
             ClassA = yourClassA;
       }
       public void SomeWhateverMethod()
       {
            ClassA.DoSomething();
            .....
       }
