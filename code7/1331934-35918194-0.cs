    namespace WpfApplication4
    {
            /// <summary>
            /// Interaction logic for MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        
                public MainWindow()
                {
                    InitializeComponent();
                }
    
                private void button1_Click(object sender, EventArgs e)
                {
                    DataTable table = null;
                    string query = "select * from student";
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(this.connectionString))
                        {
                            connection.Open();
                            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                            {
                                table = new DataTable();
                                adapter.Fill(table);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
        
                    }
        
                    if (table != null)
                    {
                        dataGridView1.DataSource = table;
                    }
                }
            }
    }
