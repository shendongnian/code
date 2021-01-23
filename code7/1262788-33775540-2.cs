    public event EventHandler Button1Click
    {
        add { button1.Click += value; }
        remove { button1.Click -= value; }
    }
