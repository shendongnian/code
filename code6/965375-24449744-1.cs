    HubPage: Page, INotifyPropertyChanged
    {
        private void OnPropertyChanged(string propName)
        { if (this.PropertyChanged != null)
              this.PropertyChanged(this, new PropertyChangedEventArgs(propName)); }
    
        ...
        
        public HubPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            List<Category> test = new List<Category>();
            test.Add(new Category(1, "two"));
            
             this.Categories = new ObservableCollection<Category>(test);
        }
    
        private ObservableCollection<Category> _Categories;
     
        ObservableCollection<Category> Categories
        {
            get {return this._Categories;}
            private set 
            {
                this._Categories = value;
                this.OnPropertyChanged("Categories");
            }
         }
    }
    
       <Page DataContext="{Binding RelativeSource={RelativeSource Self}}" 
       ...
       <GridView ItemsSource="{Binding Categories}" >
                <GridView.ItemTemplate>
                    <DataTemplate>
                        <StackPanel>
                            <TextBlock Text="{Binding Name}"></TextBlock>
                            <TextBlock Text="{Binding ID}"></TextBlock>
                        </StackPanel>
                    </DataTemplate>
                </GridView.ItemTemplate>
       </GridView>
