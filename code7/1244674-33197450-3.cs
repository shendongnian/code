            protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += AssociatedObjectOnLoaded;
        }
        private void AssociatedObjectOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var treeView = sender as TreeView;
            if(treeView == null) return;
            treeView.ItemsSource.Cast<object>().ToList().ForEach(o =>
            {
                var treeViewItem = treeView.ItemContainerGenerator.ContainerFromItem(o) as TreeViewItem;
                if(treeViewItem == null) return;
                treeViewItem.Expanded += TreeViewItemOnExpanded;
                _list.Add(treeViewItem);
            });
        }
        private void TreeViewItemOnExpanded(object sender, RoutedEventArgs routedEventArgs)
        {
            if(OnExpandedAction == null)
                return;
            OnExpandedAction(sender, routedEventArgs);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Loaded -= AssociatedObjectOnLoaded;
            _list.ForEach(item => item.Expanded -= TreeViewItemOnExpanded);
            _list.Clear();
        }
