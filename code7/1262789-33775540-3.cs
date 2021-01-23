    public MultiButtons()
    {
        InitializeComponents();
        button1.Click += ButtonClick;
        button2.Click += ButtonClick;
        button3.Click += ButtonClick;
    }
    // this handles all of your clicks
    private void ButtonClick(object sender, EventArgs e)
    {
        if (sender == button1)
            OnButton1Click(EventArgs.Empty);
        // TODO: the other buttons...
    }
    public event EventHandler Button1Click;
    protected virtual void OnButton1Click(EventArgs e)
    {
        var handler = Button1Click;        
        if (handler != null)
            handler(this, e);
        else
            // you can call some default action if there is no event subscription
            DefaultButton1Click();
    }
