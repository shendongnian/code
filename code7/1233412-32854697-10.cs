         private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CDFViewModel model = new CDFViewModel();
            ScatterSeries series;
            for (int i = 0; i < model.CDFPlotCollection.Count; i++)
            {
                series = new ScatterSeries();
                series.DependentValuePath = "Y";
                series.IndependentValuePath = "X";
                series.ItemsSource = model.CDFPlotCollection[i];
                chart1.Series.Add(series);
            }
        }
