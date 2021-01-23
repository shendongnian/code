    public class ViewModel : INotifyPropertyChanged
        {
            public ViewModel()
            {
                SuggestedApps = new ObservableCollection<App>();
                SuggestedApps.CollectionChanged += SuggestedApps_CollectionChanged;
            }
    
            private void SuggestedApps_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                OnPropertyChanged("SuggestedApps");
            }
    
            private ObservableCollection<App> suggestedApps;
    
            public ObservableCollection<App> SuggestedApps
            {
                get
                {
                    return suggestedApps;
                }
                set
                {
                    suggestedApps = value;
                    OnPropertyChanged("SuggestedApps");
                }
            }
    
            public void SuggestForSearch(string searchExpression)
            {
                SuggestedApps.Clear();
    
    
                //Assumgin EF as DataSource
                //You can use another Search algorithm here instead of String.Contains
                foreach(var item in yourDataSource.Apps.Where(x => x.Name.Contains(searchExpression.Trim())))
                {
                    SuggestedApps.Add(item);
                }
                                                     
            }
    
    
            public void OnPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
