    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Windows.Threading;
    
    namespace WpfApplication2
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                System.Random rand = new System.Random();
                
                for (int i = 0; i < 10; i++)
                {
                    int randInt = rand.Next(100, 1000);
                    string randStr = randInt.ToString();
                    this.AddListViewItem(randStr, (Severity)(i % 5)); //5 is number of Severities
                }
            }
    
            public void AddListViewItem(string value, Severity severity)
            {
                ListViewItem item = new ListViewItem();
                item.Content = value.ToString();
                SolidColorBrush bgColorBrush = OutputBackgroundConverter.Convert(severity);
                item.Background = bgColorBrush;
                myListView.Items.Add(item);
            }
        }
    
        public enum Severity
        {
            CRITIC = 0,
            DEBUG = 1,
            ERROR = 2,
            MESSAGE = 3,
            WARNING = 4,
        }
    
        class OutputBackgroundConverter
        {
            public static SolidColorBrush Convert(Severity severity)
            {
                string bgColor = "d3d3d3"; //Gray;
    
                switch (severity)
                {
                    case Severity.CRITIC:
                        bgColor = "27ae60"; //carrot orange
                        break;
                    case Severity.DEBUG:
                        bgColor = "3498db"; //peter river blue
                        break;
                    case Severity.ERROR:
                        bgColor = "e74c3c"; //alizarin red
                        break;
                    case Severity.MESSAGE:
                        bgColor = "95a5a6"; //concrete grey
                        break;
                    case Severity.WARNING:
                        bgColor = "9b59b6"; //amethyst purple
                        break;
                }
    
                SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + bgColor));
    
                return brush;
            }
    
        }
    }
