    public class ListViewModel : ViewModelBase
    {
        public ObservableCollection<StructOfList> Items 
        {
            get; private set;
        }
    
        public ListViewModel()
        {
            Items = new ObservableCollection<StructOfList>();
            Items.Add(new StructOfList { Amount = 10, FirstName = "Test", SecondName = "Test" });
            AsyncDataLoad();
        }
    
        public void async AsyncDataLoad()
        {
            await Task.Run(()=> AddItemsToList());
        }
    
        public void AddItemsToList()
        {
            for (int i = 0; i < 10; i++)
            {
                Application.Current.Dispatcher.Invoke(() => Items.Add(new StructOfList {FirstName = "First" , SecondName = "Second" , Amount = i}));
            }
        }
    }
