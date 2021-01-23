    public class Pager
    {
        // continued...
        private listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedEntryProperty = (sender as ListBox).SelectedItem;
        }
    }
