    public SomePage ()
    {
        AppVersion = "some text" + ...;
        InitializeComponent ();
        DataContext = this; // More common is to have a separate viewmodel class, though.
    }
