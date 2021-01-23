    public class Item : INotifyPropertyChanged
    {
        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        public double Y { get; set; }
        public double Height { get; set; }
        double _offset;
        public double Offset
        {
            get { return _offset; }
            set
            {
                _offset = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Text));
            }
        }
        public string Text => $"Y={Y} Height={Height} Offset={Offset}";
    }
    public partial class MainWindow : Window
    {
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
                Items.Add(new Item { Y = i * 40 });
            DataContext = this;
        }
        void Border_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var border = (Border)sender;
            var current = (Item)border.DataContext;
            current.Height = border.ActualHeight;
            // recalculate offset
            var y = Items[0].Y;
            foreach (var item in Items)
            {
                item.Offset = y > item.Y ? y : item.Y;
                y = item.Offset + item.Height;
            }
        }
    }
