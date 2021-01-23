    private void MyButton1_Click(object sender, RoutedEventArgs e)
    {
        MySlider.Minimum = 1.6;
        MySlider.Maximum = 8;
        MySlider.CoerceValue(Slider.ValueProperty); //Set breakpoint, watch MySlider.Value before and after breakpoint.
    }
