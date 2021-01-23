    <ListView ItemsSource="{Binding ModelCollection,Mode=TwoWay}" 
              SelectedItem="{Binding SelectedModelItem}" />
    private tbl_Model _modelItem;
    public tbl_Model SelectedModelItem 
    {
        get { return _modelItem; }
        private set
        {
            _modelItem = value;
            NotifyPropertyChanged("SelectedModelItem");
        }
    }
    public void Update()
    {
       SelectedModelItem.Model_No = "102";//Ui get notified, cause its a ModelItem from your Collection
    }
