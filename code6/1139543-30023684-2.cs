    public string userName;
    
    public void UNameInput_TextChanged(object sender, TextChangedEventArgs e)
    {
        userName = UNameInput.Text;            
    }
    
    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        someWindow window = new someWindow(userName);
        page.ShowDialog();
    }
