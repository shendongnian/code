    public ObservableCollection<MyProduct> Products {get;set;}
    private MyProduct selectedProduct;
    public MyProduct SelectedProduct
    {
    get {return selectedProduct;}
    set {
    if (selectedProduct != value) {
    selectedProducat = value;
    RaisePropertyChanged(()=>SelectedProduct;
    }
    }
    }
