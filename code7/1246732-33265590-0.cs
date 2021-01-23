    private void LoginBtn_Click(object sender, RoutedEventArgs e)
    {
        LoginDialog _dialog = Application.Current.Windows.OfType<LoginDialog>().FirstOrDefault();
        if (_dialog == null)
        {
            _dialog = new LoginDialog();
        }
        _dialog.Show();
    }
