            // create TreeViewItem.
            FrameworkElementFactory treeViewItem = new FrameworkElementFactory(typeof(TreeViewItem));
            treeViewItem.SetBinding(TreeViewItem.ItemsSourceProperty, new Binding("GroupList"));
            treeViewItem.SetValue(TreeViewItem.ItemTemplateSelectorProperty,
                                   new TreeViewItemTemplateSelector(_viewModel));
            hierarchicalTemplate.VisualTree = treeViewItem;
