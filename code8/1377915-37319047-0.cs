    public class MyVMClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<MyData> AllDataObjects { get; set; }
        private MyData CurrentSelection_ { get; set; }
        public MyData CurrentSelection
        {
            get { return CurrentSelection_; }
            set
            {
                CurrentSelection_ = value;
                OnPropertyChanged(nameof(CurrentSelection));
            }
        }
        public MyVM(List<MyData> allDataObjects)
        {
            AllDataObjects = allDataObjects;
        }
    }
