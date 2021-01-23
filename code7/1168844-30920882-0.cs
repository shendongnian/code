    public class ViewModel: INotifyPropertyChanged
    {
        private CollectionViewSource data = new CollectionViewSource();
        private ObservableCollection<Child> observableChilds = new ObservableCollection<Child>();
    
        public ViewModel()
        {
            var model = new Model();
            model.ChildList.Add(new Child { Name = "Child 1" });
            model.ChildList.Add(new Child { Name = "Child 2" });
            model.ChildList.Add(new Child { Name = "Child 3" });
            model.ChildList.Add(new Child { Name = "Child 4" });
            //Populate ObservableCollection
            model.ChildList.ToList().ForEach(child => observableChilds.Add(child));
    
            this.data.Source = observableChilds;
            ApplyFilterCommand = new DelegateCommand(OnApplyFilterCommand);
        }
    
        public ICollectionView ChildCollection
        {
            get { return data.View; }
        }
    
        public DelegateCommand ApplyFilterCommand { get; set; }
    
        private void OnApplyFilterCommand()
        {
            data.View.Filter = new Predicate<object>(x => ((Child)x).Name == "Child 1");
            OnPropertyChanged("ChildCollection");
        }
    }
    
    //Sample Model used
    public class Model
    {
        public Model() 
        {
            ChildList = new HashSet<Child>();
        }
    
        public ICollection<Child> ChildList { get; set; }
    }
    
    public class Child
    {
        public string Name { get; set; }
    }
    //View
    <ListBox ItemsSource="{Binding Path = ChildCollection}" >
        <ListBox.ItemTemplate>
            <DataTemplate>
                <Label Content="{Binding Name}"/>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
                
    <Button Command="{Binding ApplyFilterCommand}"/>
        
