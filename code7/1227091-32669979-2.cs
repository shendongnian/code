    <Grid Name="ButtonsContainer">
        <ListBox Name="lb_GlobalList">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <StackPanel>
                            <Button Tag="{Binding SomeNumberValue}" Content="Click me" Click="Button_Click" />
                            <TextBlock Text="{Binding Path=SomeNumberValue, StringFormat={}I am from {0}}" />
                        </StackPanel>
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<SomeBusinessObject> businessObjects = new List<SomeBusinessObject>();
            for (int i = 0; i < 5; i++)
            {
                businessObjects.Add(new SomeBusinessObject() { SomeNumberValue = i, SomeTextValue = "sample text" });
            }
            lb_GlobalList.ItemsSource = businessObjects;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("I am from " + (sender as Button).Tag.ToString());
        }
    }
    public class SomeBusinessObject
    {
        public int SomeNumberValue { get; set; }
        public string SomeTextValue { get; set; }
    }
