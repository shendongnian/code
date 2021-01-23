    public MyEventArgs : EventArgs
    {
    	public string MyProperty { get; set; }
    	public string MyProperty2 { get; set; }
    }
    
    public event EventHandler<MyEventArgs> MyEvent;
    ...
    if (this.MyEvent != null)
    {
    	this.MyEvent(this, new MyEventArgs { MyProperty = "foo", MyProperty2 = "bar" });
    }
    ...
    // I didn't change the event handler. If SomeMethod() doesn't need MyProperty2, everything is just fine already
    someInstance.MyEvent += (sender, e) => SomeMethod(e.MyProperty);
