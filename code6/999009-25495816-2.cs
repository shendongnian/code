    private void LV_Options_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (var item in e.AddedItems.OfType<MyTBLViewModel>())
        {
            item.Highlight = new SolidColorBrush(Color.LightSteelBlue);
            item.ItemFontSize = 17;
        }
        foreach (var item in e.RemovedItems.OfType<MyTBLViewModel>())
        {
            item.Highlight = new SolidColorBrush(Colors.Transparent);
            item.ItemFontSize = 12;
        }
    }
