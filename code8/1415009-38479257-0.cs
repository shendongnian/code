    public partial class TextBlockExample : Window
    {
        ThreadExampleViewModel viewModel = new ThreadExampleViewModel();
        public TextBlockExample()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            /// Background thread Thread to run your logic 
            Thread thread = new Thread(YourLogicToUpdateTextBlock);
            thread.IsBackground = true;
            thread.Start();
        }
        private void YourLogicToUpdateTextBlock()
        {
            /// Example i am updating with i value.
            for (int i = 0; i < 1000; i++)
            {
                viewModel.Name = i + " Conut";
                Thread.Sleep(1000);
            }
        }
    }
    <Grid>
        <StackPanel>
            <TextBlock x:Name="txtName" Text="{Binding Name}" Height="30" Width="100" Margin="10"/>
            <Button x:Name="btnClick" Content="Click" Height="30" Width="100" Margin="10" Click="btnClick_Click"/>
        </StackPanel>
    </Grid>
    public class ThreadExampleViewModel : INotifyPropertyChanged
    {
        private string name = "Hello";
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
