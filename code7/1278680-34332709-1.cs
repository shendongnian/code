    public class MainViewModel:BaseObservableObject
    {
        public MainViewModel()
        {
            DataSource = new ObservableCollection<BaseData>(new List<BaseData>
            {
                new BaseData {Name = "John"},
                new BaseData {Name = "Ron"},
                new BaseData {Name = "Bob"},
            });
        }
        public ObservableCollection<BaseData> DataSource { get; set; }
    }
