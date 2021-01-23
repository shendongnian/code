    public MainPage()
    {
        this.InitializeComponent();
    
        var runtimeEvent = this.myButton.GetType().GetRuntimeEvent("Click");
        var handlerMethodInfo = this.GetType().GetMethod("OnClick");
    
        var delegateHandler = handlerMethodInfo.CreateDelegate(runtimeEvent.EventHandlerType, this);
    
        Func<Delegate, EventRegistrationToken> add = (a) => {
            return (EventRegistrationToken)runtimeEvent.AddMethod.Invoke(this.myButton, new object[] { a });
        };
    
        Action<EventRegistrationToken> remove = (a) => { runtimeEvent.RemoveMethod.Invoke(runtimeEvent, new object[] { a }); };
    
        WindowsRuntimeMarshal.AddEventHandler(add, remove, delegateHandler);
    }
    
    public void OnClick(Object sender, RoutedEventArgs e)
    {
    
    } 
