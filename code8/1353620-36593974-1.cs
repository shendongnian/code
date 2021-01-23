    private void MyPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (PivotItem pivotItem in MyPivot.Items)
        {
            if (pivotItem == MyPivot.Items[MyPivot.SelectedIndex])
            {
                ((TextBlock)pivotItem.Header).Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
            }
            else
            {
                ((TextBlock)pivotItem.Header).Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(115, 123, 120, 130));
            }
        }
    }
