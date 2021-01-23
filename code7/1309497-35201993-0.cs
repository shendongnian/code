    public Task<string> DoSomething()
    {
      Class1.\u003CDoSomething\u003Ed__0 stateMachine;
      stateMachine.\u003C\u003E4__this = this;
      stateMachine.\u003C\u003Et__builder = AsyncTaskMethodBuilder<string>.Create();
      stateMachine.\u003C\u003E1__state = -1;
      stateMachine.\u003C\u003Et__builder.Start<Class1.\u003CDoSomething\u003Ed__0>(ref stateMachine);
      return stateMachine.\u003C\u003Et__builder.Task;
    }
    private Task<string> DoSomethingElse()
    {
      return Task.FromResult<string>("test");
    }
