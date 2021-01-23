    private void UpDownBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if ((double) e.NewValue == Spinner.Minimum)
            Spinner.Value = Spinner.Maximum - 1;
        else if ((double) e.NewValue == Spinner.Maximum)
            Spinner.Value = Spinner.Minimum + 1;
    }
    private void Min_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        double minimum;
        if (double.TryParse(Min.Text, out minimum))
            Spinner.Minimum = minimum - 1;
    }
    private void Max_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        double maximum;
        if (double.TryParse(Max.Text, out maximum))
            Spinner.Maximum = maximum + 1;
    }
