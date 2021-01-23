    public class ViewModel : ObservableObject
    {
        private ObservableCollection<TabItem> tabItems;
        private RelayCommand<object> RemoveCommand;
    
        public ObservableCollection<TabItem> TabItems
        {
            get { return tabItems ?? (tabItems = new ObservableCollection<TabItem>()); }
        }
    
        public ViewModel()
        {
            TabItems.Add(new TabItem { Header = "One", Content = DateTime.Now.ToLongDateString() });
            TabItems.Add(new TabItem { Header = "Two", Content = DateTime.Now.ToLongDateString() });
            TabItems.Add(new TabItem { Header = "Three", Content = DateTime.Now.ToLongDateString() });
    
            RemoveCommand = new RelayCommand<object>(RemoveItemExecute);
        }
    
        public void AddContentItem()
        {
            TabItems.Add(new TabItem { Header = "Three", Content = DateTime.Now.ToLongDateString() });
        }
    
        private void RemoveItemExecute(object param)
        {
        	var tabItem = param as TabItem;
        	if (tabItem != null)
        	{
        		TabItems.Remove(tabItem);
        	}
        }
    }
