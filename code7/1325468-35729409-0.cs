    class GameStateMachine<T> where T : GameViewMachine
    {
    }
    
    abstract class GameViewMachine
    {
      public int Count { get; }
      public IQueue InputQueue { get; }
    }
