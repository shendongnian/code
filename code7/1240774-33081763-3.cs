    public class Pager
    {
        // continued...
        // *Updated*
        private listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedEntry = (sender as ListBox).SelectedItem;
        }
    }
