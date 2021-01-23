    private void ClearAndBuildGrid()
    {
        foreach (var item in Items)
        {
            var parent = System.Windows.Media.VisualTreeHelper.GetParent(item) as Grid;
            if (parent != null)
                parent.Children.Remove(item);
        }
        MainGrid.Children.Clear();
