    private void cb_Checked(object sender, RoutedEventArgs e)
    {
        ListViewItem listViewItem =
           GetVisualAncestor<ListViewItem>((DependencyObject)sender);
        listbox3.SelectedValue =
            listbox3.ItemContainerGenerator.ItemFromContainer(listViewItem);
    }
    private static T GetVisualAncestor<T>(DependencyObject o) where T : DependencyObject
    {
        do
        {
            o = VisualTreeHelper.GetParent(o);
        } while (o != null && !typeof(T).IsAssignableFrom(o.GetType()));
        return (T)o;
    }
