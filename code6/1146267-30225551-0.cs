    private void RunAsync()
	{
		string param = "Hi";
		Task.Run(() => MethodWithParameter(param));
	}
	
    private void MethodWithParameter(string param)
	{
        //Do stuff
	}
