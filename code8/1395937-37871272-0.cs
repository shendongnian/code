        public MainWindow()
        {
            InitializeComponent();
            UpdateItems(); // Maybe initialize here?
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProjectComboBox.Items.Clear(); // Remove this. AFAIK, the selected item will be cleared.
            UpdateItems();
        }
        private void UpdateItems()
        {
            try
            {
                using(SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Database1;Integrated Security=True"))
                {
                    con.Open();
                    SqlDataAdapter ProjectTableTableAdapter = new SqlDataAdapter("SELECT * FROM PROJECTNAME", con);
                    DataSet1 ds = new DataSet1();
                    ProjectTableTableAdapter.Fill(ds, "t");
    
                    ProjectComboBox.ItemsSource = ds.Tables["t"].DefaultView;
                    ProjectComboBox.DisplayMemberPath = "ProjectName";
                    ProjectComboBox.SelectedValuePath = "RFIDirectory";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
        }
        <ComboBox x:Name="ProjectComboBox"
              ItemsSource="{Binding Path=ProjectTable}" // Not sure of what the impact will be by adding this because you have already defined the item source on your code-behind. I'd prefer you remove this and use XAML binding when you're following a design pattern like MVVM or MVPVM.
              DisplayMemberPath="ProjectName" 
              SelectedValuePath="RFIDirectory" 
              HorizontalAlignment="Left" 
              VerticalAlignment="Top" 
              Width="297" Height="26" 
              SelectionChanged="comboBox_SelectionChanged">
        </ComboBox>
