    private void cbKiesTafel_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string KiesTafel = ((ComboBoxItem)cbKiesTafel.SelectedItem).Content.ToString();
        int kies = 0;
        int.TryParse(KiesTafel, out kies);
        var tafels = Enumerable.Range(1, 10).Select(i => string.Format("10 x {0} = {1}", i, i * 10));
        lbTafels.ItemSource = tafels;
    }
