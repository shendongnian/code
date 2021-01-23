    public class Model : INotifyPropertyChanged
    {
        public ObservableCollection<DataGridRowModel> Colection { get; set; }
        public Model()
        {
            Colection = new ObservableCollection<DataGridRowModel>();
        }
        public void AddElement()
        {
            Colection.Add(new DataGridRowModel { Name = "Test" });
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
