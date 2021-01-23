    System.Windows.Controls.Button b = new System.Windows.Controls.Button();
    IFrameworkElement ife = b.AsIFrameworkElement();
    
    ife.DataContext = "it works!";
    
    Debug.Assert(b.DataContext == ife.DataContext);
