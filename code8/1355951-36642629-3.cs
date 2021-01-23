    class ActionState
    {
      public bool Condition1{get;set;}
      public bool Condition2{get;set;}
      public bool Condition3{get;set;}
    }
    
    abstract class ActionDispatcher
    {
      protected abstract void ExecuteAction1();
      protected abstract void ExecuteAction2();
      protected abstract void ExecuteAction2();
    
      public void Action1(ActionState state)
      {
        if(state.Condition1 && state.Condition2)
        {
          ExecuteAction1();
        }
      }
    
      public void Action2(ActionState state)
      {
        if(state.Condition2 && state.Condition3)
        {
          ExecuteAction2();
        }
      }
    
      public void Action3(ActionState state)
      {
        if(state.Condition1 && state.Condition2 && state.Condition3)
        {
          ExecuteAction3();
        }
      }
      public void AllActions(ActionState state)
      {
        // Execute all actions depending on the state
        Action1(state);
        Action2(state);
        Action3(state);
      }
    }
