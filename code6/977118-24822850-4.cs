    //The main window class
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Init the Keywords first
            Keywords.Add("hallo", Brushes.Blue);
            Keywords.Add("my", Brushes.Red);
            Keywords.Add("name", Brushes.Green);
            //Add some items to the ListView
            lv.Items.Add("hallo my name");
            lv.Items.Add("hello my name");
            lv.Items.Add("goodbye your name");            
        }
        //This dictionary used to hold your keywords corresponding to their Brush
        public static Dictionary<string, Brush> Keywords = new Dictionary<string,Brush>();
    }
    //The converter class
    public class InlinesConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var content = Convert.ToString(value);
            var dict = MainWindow.Keywords;
            var outString = "<TextBlock xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"  xml:space=\"preserve\">";
            foreach(var word in content.Split(' ')){
                var converted = word;
                Brush fg;
                if (dict.TryGetValue(word, out fg)) {
                    var run = new Run(word);
                    run.Foreground = fg;
                    converted = System.Windows.Markup.XamlWriter.Save(run);
                }
                outString += converted + " ";
            }
            outString += "</TextBlock>";            
            return System.Windows.Markup.XamlReader.Parse(outString);            
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
