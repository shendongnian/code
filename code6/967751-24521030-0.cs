    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        var viewModel = this.DataContext as UserViewModel;
        viewModel.AlarmStatus = "On";
    }
