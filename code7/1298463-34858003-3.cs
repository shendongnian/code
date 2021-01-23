    public class MainViewModel
    {
        public ObservableCollection<TestItem> Items { get; set; } = new ObservableCollection<TestItem> { new TestItem() { Id = 1, Name = "Foo" }, new TestItem() { Id = 2, Name = "Bar" } };
    
        public ICommand GoCommand => new DelegateCommand(Go);
    
        void Go()
        {
            MessageBox.Show(string.Join(Environment.NewLine, Items.Where(x => x.IsSelected).Select(x => x.Name)));
        }
    }
