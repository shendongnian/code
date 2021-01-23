    public static string userName { get; private set; }
    public void UNameInput_TextChanged(object sender, TextChangedEventArgs e)
    {
        userName = UNameInput.Text;       
    }
