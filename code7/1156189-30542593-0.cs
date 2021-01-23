    class MyStateMachine
    {
      private readonly Func<string> askForName;
    
      public MyStateMachine(Func<string> askForName)
      {
        this.askForName = askForName;
      }
    
      // ...
    
      void StateTransitionForActionX()
      {
        var name = askForName();
    
        // ...
      }
    }
    
    public MyStateMachine CreateMachine()
    {
      return new MyStateMachine
       (
         () => 
         {
           Console.WriteLine("Please, enter your name: ");
           return Console.ReadLine();
         }
       );
    }
