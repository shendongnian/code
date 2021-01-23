    private  StackPanel TestPanel;
    private  TextBlock testblock;
    
    public MainPage()
    {
        this.InitializeComponent();
        testblock = new TextBlock();
        TestPanel = new StackPanel();
        TestPanel.Children.Add(testblock);
    }
    
    private void Test_Click(object sender, RoutedEventArgs e)
    {
        if (listView.Items.Contains(TestPanel))
        {
            textBox5.Text = "existing item";
        }
        else
        {
            testblock.Text = textBox6.Text;
            listView.Items.Add(TestPanel);
        }
    }
