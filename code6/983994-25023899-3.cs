    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var vm = (MyViewModel)DataContext;
        vm.TextColor = Brushes.Blue;
    }
