    private void start_Button(object sender, RoutedEventArgs e)
    {
        YourViewModel yourViewModel = (sender as Button).DataContext as YourViewModel ;
        if (yourViewModel != null)
        {
            yourViewModel.ProgressBarValue = <<The value you want to set>>;
         }
    }
