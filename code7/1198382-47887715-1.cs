    public ICommand LoginCommand { get; }
    LoginCommand = new DelegateCommand<object>(
	x =>
	{
         // x will be containing 12345
         // your code 
    });
