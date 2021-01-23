    async void EventMethod()
    {
      try 
      { 
        await Helper.Handler1(); //Make sure this return Task
      }
      catch(Exception ex)
      {
      }
      finally
      {
        GlobalVariable.ExecutionCompleted = true;
      }
    }
