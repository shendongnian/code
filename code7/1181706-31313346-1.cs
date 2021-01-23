    public void ContainerSelected(object sender, RoutedEventArgs e) {
        EditableControlContainer ecc = (EditableControlContainer)sender;
        ItemContainerGenerator generator = grdArrears.ItemContainerGenerator;
        foreach (var item in grdArrears.Items) {
            var itemContainer = generator.ContainerFromItem(item);
            foreach (var presenter in GetChildrenOfType<ContentPresenter>(itemContainer))
            {
                var myControl = presenter.ContentTemplate.FindName("MyControl", presenter);
                // Do stuff with your cell control
            }
        }
    }
    private IEnumerable<T> GetChildrenOfType<T>(DependencyObject parent) where T : DependencyObject
    {
        int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < childrenCount; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is T)
                yield return (T)child;
            var childrenOfType = GetChildrenOfType<T>(child);
            foreach (var childOfType in childrenOfType)
                yield return childOfType;
        }
    }
