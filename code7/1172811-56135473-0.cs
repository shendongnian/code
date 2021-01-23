    private void ShowPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e) => ShowPasswordFunction();
    private void ShowPassword_PreviewMouseUp(object sender, MouseButtonEventArgs e) => HidePasswordFunction();
    private void ShowPassword_MouseLeave(object sender, MouseEventArgs e) => HidePasswordFunction();
    
    private void ShowPasswordFunction()
    {
        ShowPassword.Text = "HIDE";
        PasswordUnmask.Visibility = Visibility.Visible;
        PasswordHidden.Visibility = Visibility.Hidden;
        PasswordUnmask.Text = PasswordHidden.Password;
    }
    
    private void HidePasswordFunction()
    {
        ShowPassword.Text = "SHOW";
        PasswordUnmask.Visibility = Visibility.Hidden;
        PasswordHidden.Visibility = Visibility.Visible;
    }
