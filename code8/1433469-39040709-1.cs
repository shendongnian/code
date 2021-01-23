    [CompilerGenerated]
    private sealed class <DoHolyWarComplicatedDetails>d__3 : IAsyncStateMachine
    {
      public int <>1__state;
      public AsyncTaskMethodBuilder <>t__builder;
      private TaskAwaiter <>u__1;
      public <DoHolyWarComplicatedDetails>d__3()
      {
        base..ctor();
      }
      void IAsyncStateMachine.MoveNext()
      {
        int num1 = this.<>1__state;
        try
        {
          TaskAwaiter awaiter;
          int num2;
          if (num1 != 0)
          {
            awaiter = MainWindow.BurnHeretics().GetAwaiter();
            if (!awaiter.IsCompleted)
            {
              this.<>1__state = num2 = 0;
              this.<>u__1 = awaiter;
              MainWindow.<DoHolyWarComplicatedDetails>d__3 stateMachine = this;
              this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, MainWindow.<DoHolyWarComplicatedDetails>d__3>(ref awaiter, ref stateMachine);
              return;
            }
          }
          else
          {
            awaiter = this.<>u__1;
            this.<>u__1 = new TaskAwaiter();
            this.<>1__state = num2 = -1;
          }
          awaiter.GetResult();
          awaiter = new TaskAwaiter();
          Console.WriteLine("Heretics burned");
        }
        catch (Exception ex)
        {
          this.<>1__state = -2;
          this.<>t__builder.SetException(ex);
          return;
        }
        this.<>1__state = -2;
        this.<>t__builder.SetResult();
      }
      [DebuggerHidden]
      void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
      {
      }
    }
