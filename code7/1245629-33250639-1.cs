    public partial class MainWindow : Window
    {
        public List<Data> DataList { get; private set; }
        public MainWindow()
        {
            DataList = new List<Data>();
            DataList.Add(new Data { Name = "Data item 1", Value = "value 1" });
            DataList.Add(new Data { Name = "Data item 2", Value = "value 2" });
            DataList.Add(new Data { Name = "Data item 3", Value = "value 3" });
            InitializeComponent();
        }
    }
    public class Data
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
