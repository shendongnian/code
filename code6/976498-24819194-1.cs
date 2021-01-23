    private void RoleslistBox_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int i = RoleslistBox.SelectedIndex;
            ListBoxItem item = this.RoleslistBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;
            CheckBox tagregCheckBox = FindFirstElementInVisualTree<CheckBox>(item);
            tagregCheckBox.IsChecked = true;
        }
    private T FindFirstElementInVisualTree<T>(DependencyObject parentElement) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(parentElement);
            if (count == 0)
                return null;
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parentElement, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    var result = FindFirstElementInVisualTree<T>(child);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
