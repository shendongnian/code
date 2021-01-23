    public class MyViewModel
    {
       private ObservableCollection<MyListItem> _items;
       public ObservableCollection<MyListItem> Items { get { return _items};set {_items = value; RaisePropertyChanged;}
     public MyViewModel()
     {
        this.Items = new ObservableCollection<MyListItem>();
        this.LoadMyItems();
     }
     public void LoadMyItems()
     {
        this.Items.Add(new MyListItem { MyBoolProperty = true, MyStringProperty = "Hello" };
     }
    }
