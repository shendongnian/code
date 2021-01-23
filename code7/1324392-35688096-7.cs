    void StartCoroutine(IEnumerable stateMachineCreator)
    {
      IEnumerable stateMachine = stateMachineCreator.GetEnumerator();
      ScheduleOnSeparateThread(stateMachine);
    }
    
    void AdvanceStateMachineOnSeparateThread(IEnumerable stateMachine)
    {
      bool canAdvanceMore = stateMachine.MoveNext();
      if (canAdvanceMore)
      {
        var stepResult = stateMachine.Current;
        TimeSpan delay = TimeSpan.FromSeconds(0);
      
        if (stepResult is WaitForSeconds)
          delay = ((WaitForSeconds)stepResult).TimeSpan;
    
          ScheduleOnSeparateThread(stateMachine, delay);
      }
    }
