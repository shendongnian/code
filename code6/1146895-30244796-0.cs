    private void Button_Click(object sender, RoutedEventArgs e)
    {
        LbFrequentColumnItems
            .Items
            .SortDescriptions
            .Add(new SortDescription("Content", ListSortDirection.Ascending));
    }
