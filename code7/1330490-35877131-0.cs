    public sealed partial class TerminView : Page
    {
        
        public TerminView()
        {
            this.InitializeComponent();
            (this.Content as FrameworkElement).DataContext = this;
            TerminData = new List<TerminDate>();
            TerminData.Add(new TerminDate(1, 1, "Test 1"));
            TerminData.Add(new TerminDate(1, 2, "Test 2"));
        }
        public List<TerminDate> TerminData
        {
            get { return (List<TerminDate>)GetValue(TerminDataProperty); }
            set { SetValue(TerminDataProperty, value); }
        }
        public static readonly DependencyProperty TerminDataProperty = DependencyProperty.Register(
        "TerminData", typeof(List<TerminDate>), typeof(TerminView), new PropertyMetadata(default(List<TerminDate>), TerminDataPropertyChanged));
        private static void TerminDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as TerminView;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class TerminDate
    {
        public TerminDate(int row, int column, string text)
        {
            this.row = row;
            this.column = column;
            this.text = text;
        }
        public int row { get; set; }
        public int column { get; set; }
        public string text { get; set; }
    }
    public class BindingHelper
    {
        public static readonly DependencyProperty GridColumnBindingPathProperty =
            DependencyProperty.RegisterAttached(
                "GridColumnBindingPath", typeof(string), typeof(BindingHelper),
                new PropertyMetadata(null, GridBindingPathPropertyChanged));
        public static readonly DependencyProperty GridRowBindingPathProperty =
            DependencyProperty.RegisterAttached(
                "GridRowBindingPath", typeof(string), typeof(BindingHelper),
                new PropertyMetadata(null, GridBindingPathPropertyChanged));
        public static string GetGridColumnBindingPath(DependencyObject obj)
        {
            return (string)obj.GetValue(GridColumnBindingPathProperty);
        }
        public static void SetGridColumnBindingPath(DependencyObject obj, string value)
        {
            obj.SetValue(GridColumnBindingPathProperty, value);
        }
        public static string GetGridRowBindingPath(DependencyObject obj)
        {
            return (string)obj.GetValue(GridRowBindingPathProperty);
        }
        public static void SetGridRowBindingPath(DependencyObject obj, string value)
        {
            obj.SetValue(GridRowBindingPathProperty, value);
        }
        private static void GridBindingPathPropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var propertyPath = e.NewValue as string;
            if (propertyPath != null)
            {
                var gridProperty =
                    e.Property == GridColumnBindingPathProperty
                    ? Grid.ColumnProperty
                    : Grid.RowProperty;
                BindingOperations.SetBinding(
                    obj,
                    gridProperty,
                    new Binding { Path = new PropertyPath(propertyPath) });
            }
        }
    }
