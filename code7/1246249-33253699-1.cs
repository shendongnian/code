    namespace WpfItemsControl
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                this.DataContext = new DataStore();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
            }
        }
    }
    public class DataStore
    {
        public List<string> Names { get; set; }
        public DataStore()
        {
            Names = new List<string>();
            Names.Add(">");
            Names.Add(">");
            Names.Add(">");
            Names.Add(">");
            Names.Add(">");
        }
    }
