    class MyViewModel : ObservableObject
    {
        public ObservableCollection<MyDataItem> DataItems {get; private set;}
        public MyViewModel()
        {
            this.DataItems = new ObservableCollection<MyDataItem>();
        }
    }
