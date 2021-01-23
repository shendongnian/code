    public partial class FooBarSample : Window
    {
       public FooBarSample()
       {
           InitializeComponent();
           PopulateCollection()
       }
    }
 
    private void PopulateCollection()
    {
       ObservableCollection<Item> items = new ObservableCollection<Item>();
       items.Add(new Item() { Name = "Jack London", Age = 42, Mail = "jackLondon@london-family.com", Images = new List<ItemImages>()
       {
          new ItemImages() {Name="1" }, new ItemImages() {Name="2" }, new ItemImages() {Name="3" },
       } });
       listView.ItemsSource = items;
   }
