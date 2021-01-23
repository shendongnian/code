        public class MainViewModel
    {
        private ObservableCollection<SelectionItemViewModel> items;
    
        public MainViewModel()
        {
            FillItems();
        }
    
        private void FillItems()
        {
            var models=Enumerable.Range(0, 10)
                .SelectMany(
                    index =>
                        Enumerable.Range(0, 3)
                            .Select(i => new Model() {Id = index, Name = string.Format("Name_{0}_{1}", index, i)})).Select(
                                delegate(Model m)
                                {
                                    var selectionItemViewModel = new SelectionItemViewModel()
                                    {
                                        Value = m
                                    };
                                    selectionItemViewModel.PropertyChanged += OnModelSelectionChanged;
                                    return selectionItemViewModel;
                                });
    
            Items=new ObservableCollection<SelectionItemViewModel>(models);
        }
    
        private void OnModelSelectionChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                var model = sender as SelectionItemViewModel;
                foreach (var m in Items.Where(i=>i.Value.Id==model.Value.Id && model!=i))
                {
                    if (m.IsSelected != model.IsSelected)// This one to prevent infinite loop on selection, on double click there is no need for it
                    {
                        m.IsSelected = model.IsSelected;
                    }
                }
            }
        }
    
        public ObservableCollection<SelectionItemViewModel> Items
    
        {
            get { return items; }
            set { items = value; }
        }
    }
    
    public class SelectionItemViewModel:INotifyPropertyChanged
    {
        private bool isSelected;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value;
                OnPropertyChanged();//For .Net<4.5, use OnPropertyChanged("IsSelected")
            }
        }
    
        public  Model Value { get; set; }
    }
    
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
