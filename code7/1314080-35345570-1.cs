    public partial class MainWindow : Window
    {
        public List<string> Items { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Items = new List<string>();
            LoadItems();
            DataContext = this;
        }
        private void txtName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox currentTextBox = (TextBox)sender;
            if (currentTextBox.IsReadOnly)
                currentTextBox.IsReadOnly = false;
            else
                currentTextBox.IsReadOnly = true;
        }
        private void LoadItems()
        {
            Items.Add("Coffee");
            Items.Add("Sugar");
            Items.Add("Cream");
        }
    }
    <Grid>
        <ListView ItemsSource="{Binding Items}">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Name">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <TextBox Name="txtName" Text="{Binding Mode=OneTime}" IsReadOnly="True" MouseDoubleClick="txtName_MouseDoubleClick" Width="100"/>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>                    
                </GridView>                
            </ListView.View>
        </ListView>
    </Grid>
