    if (EditMode)
    {
        DemoCollection.ItemTemplate = this.Resources["EditModeTemplate"] as DataTemplate;
    }
    else
    {
        DemoCollection.ItemTemplate = this.Resources["ReaderModeTemplate"] as DataTemplate;
    }
