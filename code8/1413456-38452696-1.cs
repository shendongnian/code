    private void TabControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      // focus the tab control to lose focus on datagrids - they will then commit changes if possible.
      TabControl.Focus(); // my TabControl is x:Name="TabControl", Focus sets the focus
    }
