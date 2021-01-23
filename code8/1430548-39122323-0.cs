    private string myString;
    public delegate void MyEventHandler(string a);
    public event MyEventHandler MyPropertyChanged;
    public MyUserControl()
    {
        this.MyPropertyChanged+= new MyEventHandler(HandlePropertyChanging);
    }
    private void HandleCreditsChanging(string a)
    {
        a = myString;
    }
