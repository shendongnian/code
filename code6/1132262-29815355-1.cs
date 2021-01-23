    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ItemViewModel> MyItemsSource { get; private set; }
        public ItemViewModel SelectedItem { get... set... }
    
        public ICommand SelectItem { get; private set; }
    
        ctor()...
    
        private void ExecuteSelectItem(ItemViewModel item)
        {
            SelectedItem = item;
            foreach (var i in MyItemsSource) i.IsSelected = false;
            item.IsSelected = true;
            item.DoSomething();
        }
    }
