    public class ReportDataSet
    {
        public static ObservableCollection<TestData> testData { get; set; }
        static ReportDataSet()
        {
            testData = new ObservableCollection<TestData>();
            testData.Add(new TestData()
            {
                tiTestTab = new TabItem()
                {
                    Header = "test 1"
                }
            });
            testData.CollectionChanged += (s, e) => { OnStaticPropertyChanged("testData"); };
        }
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        protected static void OnStaticPropertyChanged(string propertyName)
        {
            var handler = StaticPropertyChanged;
            if (handler != null) handler(null, new PropertyChangedEventArgs(propertyName));
        }
    }
