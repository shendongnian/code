     private ObservableCollection<ProjectThread> _items;
    
            public ObservableCollection<ProjectThread> Items
            {
                get { return _items; }
                set
                {
                    _items = value;
                    this.NotifyPropertyChanged("Items");
                }
            }
    
            public ViewModel()
            {
                Items = new ObservableCollection<ProjectThread>();
                this.LoadJson();
            }
    
            public void LoadJson()
            {
                using (StreamReader r = new StreamReader(@"d:\file.txt"))
                {
                    string json = r.ReadToEnd();
                    Items = JsonConvert.DeserializeObject<ObservableCollection<ProjectThread>>(json);
                }
            }
