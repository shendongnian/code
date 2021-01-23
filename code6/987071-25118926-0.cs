    public class MyClass : INotifyPropertyChanged /*or derive from ModelViewBase*/
    {
        public ObservableCollection<Example> Examples { get; private set; }
    
        public IEnumerable<IGrouping<String, Example>> ExamplesGrouped
        {
            get
            {
                return from example in Examples
                            group example by example.Author into grp
                            orderby grp.Key
                            select grp; 
            }
        }
    
        public MyClass()
        {
            Examples = new ObservableCollection<Example>();
            Examples.CollectionChanged += (_, __) => RaisePropertyChanged("ExamplesGrouped");
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
