    public partial class MainWindow : Window
    {
        DataStore ds = new DataStore();
    
        public MainWindow()
        {
            InitializeComponent();
    
            Dgrid.DataContext = ds;
            Dgrid.ItemsSource = ds.DataSource.Tables[0].DefaultView;
        }
    
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataRowView item = ds.ChosenItem;
            Window1 w = new Window1(ref item); // send selected row as ref to other form
            w.Show();
        }
    }
    
       public class DataStore
       {
            public DataRowView ChosenItem { get; set; }
        
            public DataStore()
            {
                DataTable table1 = new DataTable();
                table1.Columns.Add(new DataColumn("Name", typeof(string)));
                table1.Columns.Add(new DataColumn("Address", typeof(string)));
        
                DataRow row = table1.NewRow();
                row["Name"] = "Name1";
                row["Address"] = "203 A";
                table1.Rows.Add(row);
        
                row = table1.NewRow();
                row["Name"] = "Deepak";
                row["Address"] = "BHEL Bhopal";
                table1.Rows.Add(row);
        
                ds.Tables.Add(table1);
            }
        
            DataSet ds = new DataSet();
            public DataSet DataSource { get { return ds; } }
        }
