    public MainWindow()
    {
        InitializeComponent();
    
        Button btn = new Button();
        TextBlock contextText = new TextBlock();
        var newRun = new Run("BoldGreenRunStyle");
        newRun.Style = FindResource("BoldGreenRunStyle") as Style;
        contextText.Inlines.Add(newRun);
    
        newRun = new Run("ItalicRedRunStyle");
        newRun.Style = FindResource("ItalicRedRunStyle") as Style;
        contextText.Inlines.Add(newRun);
    
        newRun = new Run("ThinPurpleRunStyle");
        newRun.Style = FindResource("ThinPurpleRunStyle") as Style;
        contextText.Inlines.Add(newRun);
    
        btn.Content = contextText;
    
        Container.Children.Add(btn);
    }
