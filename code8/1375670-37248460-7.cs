    private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       ItemContainerGenerator generator = this.listView.ItemContainerGenerator;
       ListBoxItem selectedItem = (ListBoxItem)generator.ContainerFromIndex(listView.SelectedIndex);
       Label aLabel = GetChildrenByType(selectedItem, typeof(Label), "label") as Label;
       if (aLabel != null)
       {
          MessageBox.Show("We've found Label with name 'label': " + aLabel.Content);
       }
       else
       {
          MessageBox.Show("There is no such Label");
       }
    }
