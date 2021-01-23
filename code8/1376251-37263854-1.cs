        public partial class MainWindow : Window
    {
    SqlConnection db = new SqlConnection("Your Connection String Here");
        public MainWindow()
        {
            InitializeComponent();
            loadCombo();
        }
        private void loadCombo()
        {
            SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE';", db);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                comboBox.Items.Add(row[0]);
            }
        }
        private DataTable loadDataGrid(String inTableName )
        {
            SqlCommand cmd = new SqlCommand("SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '"+ inTableName + "';", db);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = e.AddedItems[0].ToString(); ;
            dataGrid.ItemsSource = loadDataGrid(text).DefaultView;
        }
    }
