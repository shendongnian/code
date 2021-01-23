    public class Page6ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ListBoxDetail> RssItems;
    
        private Visibility _IsVisible = Visibility.Collapsed;
    
        public Visibility IsVisible
        {
            get { return _IsVisible; }
            set
            {
                if (value != _IsVisible)
                {
                    _IsVisible = value;
                    OnpropertyChanged();
                }
            }
        }
    
        public Page6ViewModel()
        {
            RssItems = new ObservableCollection<ListBoxDetail>();
            RssItems.Add(new ListBoxDetail { Title = "Item 1", DetailUri = "http://stackoverflow.com/questions/38853708/using-different-parts-of-rss-feed-in-a-universal-app-using-mvvmcross-and-command?noredirect=1#comment65137456_38853708" });
            RssItems.Add(new ListBoxDetail { Title = "Item 2", DetailUri = "https://msdn.microsoft.com/en-us/library/windows/apps/ms668604(v=vs.105).aspx" });
            RssItems.Add(new ListBoxDetail { Title = "Item 3", DetailUri = "https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx" });
        }
    
        private ListBox listBox;
    
        public void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox = sender as ListBox;
            listBox.Visibility = Visibility.Collapsed;
            IsVisible = Visibility.Visible;
        }
    
        public void IsVisible_Clicked(object sender, RoutedEventArgs e)
        {
            listBox.Visibility = Visibility.Visible;
            IsVisible = Visibility.Collapsed;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnpropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
