    //I create my dummy suppliers
    private string[] CONST_Supplies = { "Supplier 1", "Supplier 2", "Supplier 3", "Supplier 4" };
    public MainWindow()
    {
        InitializeComponent();
        //I add my dummy items into my datagrid 
        //These are the items that I want to compare prices with
        List<ViewQuoteItemList> list = new List<ViewQuoteItemList>();
        list.Add(new ViewQuoteItemList() { Item = "Item 1" });
        list.Add(new ViewQuoteItemList() { Item = "Item 2" });
        list.Add(new ViewQuoteItemList() { Item = "Item 3" });
        list.Add(new ViewQuoteItemList() { Item = "Item 4" });
        list.Add(new ViewQuoteItemList() { Item = "Item 5" });
        list.Add(new ViewQuoteItemList() { Item = "Item 6" });
        //Loading the items into the datagrid on application start
        DataGridTest.ItemsSource = list;
        //Adding my dummy suppliers to my supplier selection combobox
        foreach (var supplier in CONST_Supplies)
            ComboBoxTest.Items.Add(supplier);
    }
