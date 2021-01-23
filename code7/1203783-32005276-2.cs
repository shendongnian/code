    private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.RemovedItems.Count > 0)
            VisualStateManager.GoToState((e.RemovedItems.First() as PivotItem).Header as testControl, "Unselected", true);
        if (e.AddedItems.Count > 0)
            VisualStateManager.GoToState((e.AddedItems.First() as PivotItem).Header as testControl, "Selected", true);
    }
