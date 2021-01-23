    public UserControl1()
    {
        if (DesignerProperties.GetIsInDesignMode(this))
            this.Resources.MergedDictionaries.Add(new YourNamespaceHere.GlobalResources());
    
        InitializeComponent();
    }
