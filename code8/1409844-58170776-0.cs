        private void TextBlock_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem;
            if (e.OriginalSource is System.Windows.Documents.Run)
                treeViewItem = VisualUpwardSearch(((System.Windows.Documents.Run)e.OriginalSource).Parent as DependencyObject);
            else treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);
            if (treeViewItem != null)
            {
                treeViewItem.IsSelected = true;
                e.Handled = true;
            }
        }
