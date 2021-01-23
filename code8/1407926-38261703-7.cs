    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        ViewModel = new ViewModel();
        ViewModel.Text = "x:Bind does not work";
        this.Bindings.Update();
    }
