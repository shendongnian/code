    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Data;
    
    namespace WpfApplication6
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    
        public class ViewData : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] string propName = null)
            {
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
    
            private string item;
            public string Item { get { return item; } set { item = value; OnPropertyChanged(); } }
    
            public ViewData(string s)
            {
                Item = s;
            }
        }
        public class ViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] string propName = null)
            {
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
    
            private ObservableCollection<ViewData> items;
            public ObservableCollection<ViewData> Items { get { return items; } set { items = value; OnPropertyChanged(); } }
    
            private int highlightedIndex;
            public int HighlightedIndex { get { return highlightedIndex; } set { highlightedIndex = value; OnPropertyChanged(); } }
    
            public ViewModel()
            {
                HighlightedIndex = -1;
                Items = new ObservableCollection<ViewData>();
                for (int i = 0; i < 100; i++)
                    Items.Add(new ViewData("Item " + i));
            }
        }
    
        public class GridRowConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if (values.Length == 3)
                {
                    var item = values[0] as ViewData;
                    var items = values[1] as ObservableCollection<ViewData>;
                    var idx = -1;
                    if (values[2] is int)
                        idx = (int)values[2];
                    if (idx >= 0
                        && items != null
                        && items.Count > idx
                        && items[idx] == item)
                            return true;
                }
                return false;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
