    public class ViewModel
    {
        public ICommand MyCommand { get; set; }
        public ViewModel()
        {
            MyCommand = new AwaitableDelegateCommand(LoadDataAsync);
        }
        public async Task LoadDataAsync()
        {
            //await the loading of the listview here
        }
    }
