.xaml.cs
    namespace MyNamespace
    {
    	public partial class MainWindow : INotifyPropertyChanged
    	{
    	    private IList _selected;
    
    	    public IList Selected
    	    {
    	        get { return _selected; }
    	        set
    	        {
    	            if (Equals(value, _selected)) return;
    	            _selected = value;
    	            OnPropertyChanged();
    	        }
    	    }
    
    	    public MainWindow()
    		{
    			InitializeComponent();
    		    Selected = new List<object>();
    		    Why.ItemsSource = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    		}
            private void Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show(Selected.Cast<object>().Aggregate("", (s, info) => $"{s}{info}, ").TrimEnd(',', ' '));
                MessageBox.Show(Extensions.GetSelected(Why).Cast<object>().Aggregate("", (s, o) => $"{s}{o}, ").TrimEnd(',', ' '));
            }
    
    	    public event PropertyChangedEventHandler PropertyChanged;
    
    	    [NotifyPropertyChangedInvocator]
    	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    	}
        public class Extensions
        {
            public static readonly DependencyProperty SelectedProperty = DependencyProperty.RegisterAttached(
                "Selected", typeof(IList), typeof(Extensions), new FrameworkPropertyMetadata(default(IList), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, HookSelectionChanged));
    
            private static void HookSelectionChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                ListBox lb = sender as ListBox;
                if (lb == null)
                    throw new ArgumentException("This property currently only supports DependencyObjects inheriting from Selector.", nameof(sender));
                lb.SelectionChanged += SelectionChanged;
            }
    
            private static void SelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
                => SetSelected((ListBox)sender, ((ListBox)sender).SelectedItems.Cast<object>().ToList());
    
            public static void SetSelected(DependencyObject element, IList value) => element.SetValue(SelectedProperty, value);
    
            public static IList GetSelected(DependencyObject element) => (IList)element.GetValue(SelectedProperty);
        }
    }
