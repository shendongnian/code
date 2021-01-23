      public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                List<TestData> list = new List<TestData>();
                for (int i = 0; i < 10; i++)
                {
                    TestData item = new TestData();
                    item.Property1 = "property1" + i.ToString();
                    item.Property2 = "property2" + i.ToString();
                    item.Property3 = "property3" + i.ToString(); 
                    list.Add(item);
                }
                this.DataContext = list; 
            }
        }
    
        public class TestData
        {
            public string Property1 { get; set; }
            public string Property2 { get; set; }
            public string Property3 { get; set; } 
    
        }
    
        public class Bool2Visibility : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                bool flag = false;
                if (value != null)
                {
                    flag = System.Convert.ToBoolean(value);
                }
                return flag ? Visibility.Visible : Visibility.Collapsed;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }
    
    
        public class BindingProxy : Freezable
        {
            #region Overrides of Freezable
    
            protected override Freezable CreateInstanceCore()
            {
                return new BindingProxy();
            }
    
            #endregion
    
            public object Data
            {
                get { return (object)GetValue(DataProperty); }
                set { SetValue(DataProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty DataProperty =
                DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
        }
