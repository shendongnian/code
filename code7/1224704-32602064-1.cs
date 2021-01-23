    public LoginInterfaceControl()
    {
        this.InitializeComponent();
        abc();
    }
    
    public void abc()
    {
        
        for (int i = 0; i <= 5; i++)
        {
        
            Button newBtn = new Button()
            {
               Content = "name" + i,
               Name = "name" + i,
        
               Background = new SolidColorBrush(Colors.Black),
               VerticalAlignment = VerticalAlignment.Center,
               Opacity = 0.5
        
            };
            
           newBtn.Click += newBtn_Click;
        
           container.Opacity = 0.5;
           this.Panel.Children.Add(newBtn);
        }
    }
