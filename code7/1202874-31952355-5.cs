    private void Weight_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            MultipleConverters.Windows.Weight WeightCalculation = new Windows.Weight();
            WeightCalculation.Owner = this;
            WeightCalculation.ShowDialog(); //The code pauses here till the dialog is closed.
        }
