         private void TreeItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem workItem = sender as TreeViewItem;
            if(workItem.Items.OfType<TreeViewItem>().All(item => !item.IsMouseOver))
            {
                string workItemHeader = workItem.Header.ToString();
                string stopAt = "-";
                currentWorkIDToEdit = workItemHeader.Substring(0, workItemHeader.IndexOf(stopAt));
                workItemToEdit.Content = "Work Item To Edit: " + currentWorkIDToEdit + " ";
            }
        }
