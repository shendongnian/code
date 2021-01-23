    private void expander_Loaded(object sender, RoutedEventArgs e)
    {
        var tmp = VTHelper.FindChild<ContentPresenter>(sender as Expander);
        if (tmp != null)
        {
            tmp.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        }
    }
