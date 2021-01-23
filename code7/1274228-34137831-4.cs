    public IList Menus { get; set; }
    public Window1()
    {
        InitializeComponent();
    
        Menus = new[] { new { ContentText = "Menu1" }, new { ContentText = "Menu2" }, new { ContentText = "Menu3" } };
    
        this.DataContext = this;
    }
    private void Button_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        Panel.SetZIndex((Button)e.OriginalSource, 12);
    }
    
    private void Button_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        Panel.SetZIndex((Button)e.OriginalSource, 1);
    }
