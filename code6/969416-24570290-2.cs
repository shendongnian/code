    private void ButtonClick(object sender, ...)
    {
       var doSomething = new DoSomething();
       doSomething.StatusChanged += OnStatusChanged;
       doSomething.Do();
    }
    
    private void OnStatusChagned(string state)
    { 
       // Update the UI with the state 
    }
