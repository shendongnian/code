    private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        Slider slider = sender as Slider;
        PlayerVM viewModel = (PlayerVM)DataContext;
        viewModel.YourMethod(slider.Value);
    } 
