    private static Dictionary<int, string> filesToRead = new Dictionary<int, string>();
    private void button_get_Click(object sender, RoutedEventArgs e)
        {
            if (filesToRead.Count > 0)
            {
                filesToRead.Clear();
            }
            GetCheckedItems(treeView.Items);
            if (filesToRead.Count > 0)
            {
                label_files_r.Visibility = Visibility.Visible;
                label_files_r.Content = "files received: " + filesToRead.Count.ToString();
            }
            else
            {
                label_files_r.Visibility = Visibility.Hidden;
                System.Windows.MessageBox.Show("No files found!", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void GetCheckedItems(ItemCollection collection)
        {
            foreach (var itemRaw in collection)
            {
                var item = (TreeViewItem)itemRaw;
                if (item.Header is System.Windows.Controls.CheckBox)
                {
                    var checkBox = (System.Windows.Controls.CheckBox)item.Header;
                    if (checkBox.IsChecked == true)
                        filesToRead.Add((filesToRead.Count + 1), checkBox.Content.ToString());
                }
                else
                {
                    GetCheckedItems(item.Items);
                }
            }
        }
