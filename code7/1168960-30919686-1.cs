    private void MyTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        MyTextBox.ScrollToHome();
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MyTextBox.Text += "TEXT ";
    }
