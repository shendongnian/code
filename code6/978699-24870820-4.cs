    void RaiseTabItemSelectedEvent(string selectedItem)
    {
        SelectedTabRoutedEventArgs newEventArgs =
              new SelectedTabRoutedEventArgs(SampleUserControl.TabItemSelectedEvent, 
                                             selectedItem);
        RaiseEvent(newEventArgs);
    }
    
    private void TabControl_SelectionChanged(object sender,
                                                SelectionChangedEventArgs e)
    {
        RaiseTabItemSelectedEvent(tabControl.SelectedValue.ToString());
    }
