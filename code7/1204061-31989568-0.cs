    private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        var behavior = (BindableSelectedItemBehavior)sender;
        var generator = behavior.AssociatedObject.ItemContainerGenerator;
        var item = generator.ContainerFromItem(e.NewValue) as TreeViewItem;
        if (item != null)
        {
            item.SetValue(TreeViewItem.IsSelectedProperty, true);
        }
    }
