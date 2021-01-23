     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<SomeData> data=new List<SomeData>();
            SomeData d=new SomeData("sara");
            data.Add(d);
            d=new SomeData("jons");
            data.Add(d);
            d=new SomeData("bil");
            data.Add(d);
            d=new SomeData("rose");
            data.Add(d);
            d=new SomeData("steve");
            data.Add(d);
            listView1.DataContext = data;
        }
    }
    public class SomeData
    {
        public SomeData(string name)
        {
            Name = name;
        }
        public string Name { set; get; }
    }
