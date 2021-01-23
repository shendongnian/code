    // Raising an event on the mock
    mock.Raise(m => m.FooEvent += null, new FooEventArgs(fooValue));
    
    // Raising an event on a descendant down the hierarchy
    mock.Raise(m => m.Child.First.FooEvent += null, new FooEventArgs(fooValue));
    
    // Causing an event to raise automatically when Submit is invoked
    mock.Setup(foo => foo.Submit()).Raises(f => f.Sent += null, EventArgs.Empty);
    // The raised event would trigger behavior on the object under test, which 
    // you would make assertions about later (how its state changed as a consequence, typically)
    
    // Raising a custom event which does not adhere to the EventHandler pattern
    public delegate void MyEventHandler(int i, bool b);
    public interface IFoo
    {
      event MyEventHandler MyEvent; 
    }
    
    var mock = new Mock<IFoo>();
    ...
    // Raise passing the custom arguments expected by the event delegate
    mock.Raise(foo => foo.MyEvent += null, 25, true);
