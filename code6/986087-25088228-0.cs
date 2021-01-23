    private DelegateCommand _doSomethingCommand;
    public DoSomethingCommand {
        get {
            return _doSomethingCommand;
        }
    }
    public MyViewModel() {
        _doSomethingCommand = new DelegateCommand(OnDoSomething);
    }
    private void OnDoSomething(object o) {
        // Do something here
    }
