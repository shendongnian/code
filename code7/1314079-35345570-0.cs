    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void txtName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox currentTextBox = (TextBox)sender;
            if (currentTextBox.IsReadOnly)
                currentTextBox.IsReadOnly = false;
        }
    }
    <Grid>
        <ListView ItemsSource="{Binding Path=Collection}">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Name">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <TextBox Name="txtName" IsReadOnly="True" MouseDoubleClick="txtName_MouseDoubleClick"/>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
    </Grid>
