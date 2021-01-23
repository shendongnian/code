    public partial class MultiSelectComboBox : ComboBox
    {
    
        ...
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(IList),
            typeof(MultiSelectComboBox));
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;
            this.SelectedItem = lb.SelectedItem;
            this.SelectedItems = lb.SelectedItems;
        }
    }
