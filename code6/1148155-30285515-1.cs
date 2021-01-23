    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void listBoxItem_Focus(object sender, RoutedEventArgs e)
        {
            ListBox[] listBoxes = { listBox1, listBox2, listBox3 };
            ListBoxItem item = (ListBoxItem)sender;
            ListBox listBoxParent = GetParent<ListBox>(item);
            foreach (ListBox listBox in listBoxes)
            {
                listBox.Tag = object.ReferenceEquals(listBoxParent, listBox);
            }
        }
        private static T GetParent<T>(DependencyObject o) where T : DependencyObject
        {
            while (o != null && !(o is T))
            {
                o = VisualTreeHelper.GetParent(o);
            }
            return (T)o;
        }
    }
    class A : DependencyObject
    {
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register(
            "Name", typeof(string), typeof(A));
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
    }
    class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is bool))
            {
                return Binding.DoNothing;
            }
            return (bool)value ? Visibility.Visible : Visibility.Hidden;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
