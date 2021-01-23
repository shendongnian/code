    //Global variable
    MainViewModel vm;
    
    //Constructor
    public MyPage(){
    	//Other code
    	vm = new MainViewModel();
    	vm.Items.CollectionChanged += Items_CollectionChanged;
    	UpdateViewSource();
    }
    
    private void Items_CollectionChanged(object sender, CollectionChangedEventArgs e){
    	UpdateViewSource();
    }
    
    private void UpdateViewSource(){
    	MyCollectionViewSource.Source = vm.Items.Where(x => x.IsRead);
    }
