    @edited
  
    Xaml:
    <PasswordBox x:Name="passwordBox" MaxLength="4" PasswordChanged="PasswordBox_PasswordChanged"/>
    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
	{
        string password = "pass";
        int result;
        bool isPasswordNumeric = int.TryParse(password , out result);
  
        if (!isPasswordNumeric)
            return;
	}
