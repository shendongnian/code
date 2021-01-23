    public class DataItem
    {
        public string Name { get; set; }
        public string Ask { get; set; }
        public string Date { get; set; }
        public string Zulu { get; set; }
        public DataItem(string n, string a, string d, string z)
        {
            Name = n;
            Ask = a;
            Date = d;
            Zulu = z;
        }
    }
    public partial class MainWindow : Window
    {
        ObservableCollection<DataItem> data = new ObservableCollection<DataItem>();
        public ObservableCollection<DataItem> Data
        {
            get
            {
                return data;
            }
        }
        public MainWindow()
        {
            Data.Add(new DataItem("A", "No", "07/14", "?"));
            Data.Add(new DataItem("B", "Yes", "07/14", "!"));
            Data.Add(new DataItem("C", "Tes", "07/14", "*"));
            Data.Add(new DataItem("D", "No", "07/14", "%"));
            InitializeComponent();
            this.DataContext = this;
        }
        private void dg_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (dg != null && e != null)
            {
                string currentHeader = e.Column.Header.ToString();
                int i = 0;
                foreach (DataGridColumn dgc in (dg.Columns.OrderBy(col => col.Header.ToString())))
                {
                    if (currentHeader.CompareTo(dgc.Header.ToString()) < 0)
                    {
                        e.Column.DisplayIndex = i;
                        break;
                    }
                    i++;
                }
            }
        }
    }
