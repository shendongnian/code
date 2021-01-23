    namespace Sustenance_V_1._0
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
    
                add_species(all_species);
                link_members(all_species);
                LoadChartContents(all_species);
            }
    
            void MainPage_Loaded(object sender, RoutedEventArgs e)
            {
            }
        }
    
        //This could be in a different file, but I placed it outside the class here just to illustrate.
    
        //===========Converters==========//
        public class species_to_chart_itemsource_converter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var sp = parameter as species;
                List<Population> data = new List<Population>();
                data.Add(new Population() { Name = "Healthy", Amount = sp.healthy });
                data.Add(new Population() { Name = "Healthy", Amount = sp.sick });
                return data;
    
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return true;
            }
        }
    }
