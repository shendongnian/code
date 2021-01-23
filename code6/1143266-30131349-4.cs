    public class TabItemModel : INotifyPropertyChanged
    {
        private TabItemModel m_parent;
        private Boolean m_IsSelected;
        public TabItemModel(String name) : this(name, null)
        {
        }
        
        public TabItemModel(String name, IEnumerable<TabItemModel> children)
        {
            this.Name = name;
            
            this.Children = new ObservableCollection<TabItemModel>(children ?? Enumerable.Empty<TabItemModel>());
            foreach (var child in this.Children)
            {
                child.m_parent = this;
            }
        }
        
        public String Name
        {
            get;
            set;
        }
        public ObservableCollection<TabItemModel> Children
        {
            get;
            private set;
        }
        public Boolean IsSelected
        {
            get
            {
                return this.m_IsSelected;
            }
            set
            {
                if (value == this.m_IsSelected)
                    return;
                if (this.m_parent != null)
                    this.m_parent.IsSelected = value;
                this.m_IsSelected = value;
                this.OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged([CallerMemberName]String propertyName = null)
        {
            var propChangedDelegate = this.PropertyChanged;
            if (propChangedDelegate == null)
                return;
            propChangedDelegate(this,
                new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
