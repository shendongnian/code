    public class ItemViewModel
    {
        public string Name { get; set; }
        public ICommand Delete { get; set; }
    }
    public class MainViewModel
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>();
        }
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public void AddItem(string name)
        {
            Items.Add(new ItemViewModel
            {
                Name = name,
                Delete = new DelegateCommand(p => Items.Remove(p as ItemViewModel))
            });
        }
    }
