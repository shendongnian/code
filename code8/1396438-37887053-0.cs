    namespace Auction
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            //Class level field:
            private DispatchTimer _dt = new System.Windows.Threading.DispatcherTimer();
            public MainWindow()
            {
                InitializeComponent();
                GetData("SELECT * FROM Produs");
                btnLogout.Visibility = System.Windows.Visibility.Hidden;
                btnAdd.Visibility = System.Windows.Visibility.Hidden;
                btnBid.Visibility = System.Windows.Visibility.Hidden;
                tb.Visibility = System.Windows.Visibility.Hidden;
    
            }
    
            private void GetData(string SelectCommand)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=ISAAC;Initial Catalog=licitatie;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand(SelectCommand);
                cmd.Connection = conn;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("prod");
                sda.Fill(dt);
                myGrid.DataContext = dt;
            }
            private void btnLogin_Click(object sender, RoutedEventArgs e)
            {
                Login login = new Login();
                login.Show();
                Close();
    
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                
                Countdown(30, TimeSpan.FromSeconds(1), cur => tb.Text = cur.ToString());
            }
            void Countdown(int count, TimeSpan interval, Action<int> ts)
            {
                this._dt.Stop();
                this._dt = new System.Windows.Threading.DispatcherTimer();
                
                this._dt.Interval = interval;
                this._dt.Tick += (_, a) =>
                {
                    if (count-- == 0)
                    {
                        MessageBox.Show("You have won this product!");
                        this._dt.Stop();
                    }
                    else
                        ts(count);
                };
                ts(count);
                this._dt.Start();
            }
    
            private void btnLogout_Click(object sender, RoutedEventArgs e)
            {
                MainWindow main = new MainWindow();
                main.Show();
                Close();
                MessageBox.Show("You are not logged. Please log in to bid", "Failed", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
    
            }
    
            private void btnAdd_Click(object sender, RoutedEventArgs e)
            {
                Register reg = new Register();
                reg.Show();
                Close();
            }
    
            private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
    
                var grid = sender as DataGrid;
                var selected = grid.SelectedItem;
                if (selected == grid.SelectedItem)
                {
                    btnBid.Visibility = System.Windows.Visibility.Visible;
    
                }
            }
            private void UpdateColumn()
            {
    
            }
        }
    }
