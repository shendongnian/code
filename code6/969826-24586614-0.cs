    private void StackPanel_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.F5)
        {
            // Replace stackPanel with the name of your panel.
            foreach (UIElement child in LogicalTreeHelper.GetChildren(stackPanel))
            {
                if (KeyboardNavigation.GetTabIndex(child) == 2)
                {
                    child.Focus();
                    break;
                }
            }
        }
    }
