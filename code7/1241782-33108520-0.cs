    using System.ComponentModel;
    private ICollectionView cvs { get; set; }
    public MyControl()
    {
        InitializeComponent();
    
        cvs = CollectionViewSource.GetDefaultView(MyCollection);
        MyDataGrid.ItemsSource = cvs;
        cvs.Filter = FilterOut;
    
    }
    
    private bool FilterOut(object input)
    {
    
        MyCollectionObject obj = (input as MyCollectionObject);
    
        return (obj.ShowAll == 1);
    
    }
