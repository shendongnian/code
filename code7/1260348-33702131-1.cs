    class MainViewModel
    {
        private static readonly Random Random = new Random();
    
        public MainViewModel()
        {
            var list = new List<string>();
            for (int i = 0; i < 2000; i++)
            {
                list.Add(RandomString(8));
            }
    
            CollectionView =
                CollectionViewSource.GetDefaultView(list.OrderBy(x => x[0]).Select(x => new TestItem {Value = x}));
            CollectionView.GroupDescriptions.Add(new PropertyGroupDescription("Value", new FirstLetterConverter()));
        }
    
        public ICollectionView CollectionView { get; set; }
    
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
    
    public class TestItem
    {
        public string Value { get; set; }
    }
    
    public class FirstLetterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string s = value as string;
            if (!string.IsNullOrEmpty(s))
                return s.Substring(0, 1);
            return string.Empty;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
