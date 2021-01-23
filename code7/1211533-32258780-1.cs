    private void HeaderHandlerA(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        // HeaderHandlerA is allways called within the first PivotItem,
        // therefore I can just test whether selected index is 0 (index of the first PivotItem)
        if (mainPivot.SelectedIndex == 0)
        {
            OnSelectedItemTapped();
        }
        // else the "tapped" header was not the selected one and I do nothing
    }
    private void HeaderHandlerB(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (mainPivot.SelectedIndex == 1)
        {
            OnSelectedItemTapped();
        }
    }
