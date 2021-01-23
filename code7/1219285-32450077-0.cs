    public TextBlock txtBlck = new TextBlock();
            public MainWindow()
            {
                InitializeComponent();
     
    
                StackPanel stackPnl = new StackPanel();
                stackPnl.Orientation = Orientation.Vertical;
                stackPnl.Margin = new Thickness(10);
    
                
                txtBlck.Text = "this is a test!";
                stackPnl.Children.Add(txtBlck);
    
                Button btn = new Button();
                btn.Content = stackPnl;
                btn.Click +=btn_Click;
                myPanel.Children.Add(btn);
            }
    
            void btn_Click(object sender, RoutedEventArgs e)
            {
                txtBox.Text = txtBlck.Text;
            }
