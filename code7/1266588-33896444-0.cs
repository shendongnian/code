    public TrimmedTextBox()
    {
        InitializeComponent();
        LostFocus += TrimmedTextBox_LostFocus;
    }
    private void TrimmedTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        Text = Text.Trim();
    }
