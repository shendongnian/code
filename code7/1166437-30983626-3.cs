    public MyEventArgs : EventArgs
    {
    	public string MyProperty { get; set; }
    }
    public event EventHandler<MyEventArgs> MyEvent;
    ...
    if (this.MyEvent != null)
    {
    	this.MyEvent(this, new MyEventArgs { MyProperty = "foo" });
    }
    ...
    someInstance.MyEvent += (sender, e) => SomeMethod(e.MyProperty);
