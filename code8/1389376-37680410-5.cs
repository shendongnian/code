    object _previous;
    void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var isPreviousWasDataTab = _previous == dataTab;
        _previous = tabControl.SelectedItem; // store SelectedItem for next event
        if (isPreviousWasDataTab && MessageBox.Show("", "", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            _previous = tabControl.SelectedItem = dataTab;
    }
