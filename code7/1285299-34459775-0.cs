    public partial class ExpanderGroup : UserControl
    {
        public static readonly DependencyProperty ChildrenProperty = DependencyProperty.Register(
            "Children", typeof (ObservableCollection<Expander>), typeof (ExpanderGroup),
            new PropertyMetadata(default(ObservableCollection<Expander>)));
        public static readonly DependencyProperty ChildrenHeadersProperty = DependencyProperty.Register(
            "ChildrenHeaders", typeof (ObservableCollection<string>), typeof (ExpanderGroup),
            new PropertyMetadata(default(ObservableCollection<string>)));
        public ExpanderGroup()
        {
            InitializeComponent();
            Children = new ObservableCollection<Expander>();
            ChildrenHeaders = new ObservableCollection<string>();
        }
        public ObservableCollection<Expander> Children
        {
            get { return (ObservableCollection<Expander>) GetValue(ChildrenProperty); }
            set { SetValue(ChildrenProperty, value); }
        }
        public ObservableCollection<string> ChildrenHeaders
        {
            get { return (ObservableCollection<string>) GetValue(ChildrenHeadersProperty); }
            set { SetValue(ChildrenHeadersProperty, value); }
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            // find the corresponding expander to toggle button clicked
            // it is very primitive as it expects an exact mapping by name
            var button = (ToggleButton) sender;
            var text = (string) button.Content;
            var expander = Children.Single(s => (string) s.Header == text);
            // toggle expansion status
            expander.IsExpanded = button.IsChecked != null && (bool) button.IsChecked;
            // little helper that expands the root expander
            // (though its template should be changed for better UX)
            RootExpander.IsExpanded = Children.Any(s => s.IsExpanded);
        }
    }
