    private void cbKiesTafel_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string KiesTafel = ((ComboBoxItem)cbKiesTafel.SelectedItem).Content.ToString();
        int kies = 0;
        int.TryParse(KiesTafel, out kies);
        var tafels = Enumerable.Range(1, 10).Select(i => string.Format("{0} x {1} = {2}", kies, i, i * kies));
        lbTafels.ItemSource = tafels;
    }
