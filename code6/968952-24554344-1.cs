    private void StyleChanger_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var style = this.StyleChanger.SelectedItem as StyleDefinition;
        this.Resources.MergedDictionaries[0].Source = new Uri(style.ResourceUri, UriKind.Relative);
    }
