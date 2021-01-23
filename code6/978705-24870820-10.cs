    public class SelectedTabRoutedEventArgs : RoutedEventArgs
    {
        private readonly string selectedItem;
        public SelectedTabRoutedEventArgs(RoutedEvent routedEvent,
                                          string selectedItem)
            :base(routedEvent)
        {
            this.selectedItem = selectedItem;
        }
    
        public string SelectedItem
        {
            get
            {
                return selectedItem;
            }
        }
    }
