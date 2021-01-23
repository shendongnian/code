    public void DoSomething(){
       // other code
    
       // log it
       _eventAggregator.GetEvent<Messages.MethodCalled>().Publish("DoSomething called");
    }
