    private IEnumerable<EnhancedCheckBoxControl> GetStackPanelsToMove()
    {
        return spToSort.Children.OfType<EnhancedCheckBoxControl>()
            .Where(cb => cb.IsChecked.HasValue && cb.IsChecked.Value);
    }
    private void Button_Left(object sender, RoutedEventArgs e)
    {
        IEnumerable<EnhancedCheckBoxControl> stackPanelsToMove = GetStackPanelsToMove()
            .OrderBy(sp => spToSort.Children.IndexOf(sp));
        foreach (var spToMove in stackPanelsToMove) {
            int position = spToSort.Children.IndexOf(spToMove);
            if (position <= 0) { continue; }
            spToSort.Children.Remove(spToMove);
            spToSort.Children.Insert(position - 1, spToMove);
        }
    }
    private void Button_Right(object sender, RoutedEventArgs e)
    {
        IEnumerable<EnhancedCheckBoxControl> stackPanelsToMove = GetStackPanelsToMove()
            .OrderByDescending(sp => spToSort.Children.IndexOf(sp));
        foreach (var spToMove in stackPanelsToMove)
        {
            int position = spToSort.Children.IndexOf(spToMove);
            if (position >= spToSort.Children.Count - 1) { continue; }
            spToSort.Children.Remove(spToMove);
            spToSort.Children.Insert(position + 1, spToMove);
        }
    }
