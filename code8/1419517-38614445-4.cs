        private MyViewModel ViewModel
        {
            get { return (MyViewModel) DataContext; }
        }
        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.Password = PasswordBox.Password;
        }
