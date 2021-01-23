    public MainWindow()
    {
           // This button needs to exist on your form.
           myButton.Click += myButton_Click;
    }
    void myButton_Click(object sender, RoutedEventArgs e)
    {
        radioButton.Checked = true;
    }
    
