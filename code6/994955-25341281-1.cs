    private NodeViewModel GetNearestContainer(UIElement element)
    {
        // Walk up the element tree to the nearest tree view item.
        TreeViewItem UIContainer = FindParent<TreeViewItem>(element);
        NodeViewModel NVContainer = null;
    
        if (UIContainer != null)
        {
            NVContainer = UIContainer.DataContext as NodeViewModel;
        }
        return NVContainer;
    }
