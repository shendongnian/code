    [ContentPropertyAttribute("MainContent")]
    public partial class Tile2 : UserControl
    {
        private static readonly DependencyPropertyKey ToolbarContentKey =
             DependencyProperty.RegisterReadOnly("ToolbarContent", typeof(UIElementCollection), typeof(Tile2), new PropertyMetadata());
        public static readonly DependencyProperty ToolbarContentProperty = ToolbarContentKey.DependencyProperty;
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(Tile2), new PropertyMetadata());
        public static readonly DependencyProperty MainContentProperty =
            DependencyProperty.Register("MainContent", typeof(object), typeof(Tile2));
        public UIElementCollection ToolbarContent
        {
            get { return (UIElementCollection)GetValue(ToolbarContentProperty); }
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public object MainContent
        {
            get { return GetValue(MainContentProperty); }
            set { SetValue(MainContentProperty, value); }
        }
        public Tile2()
        {
            InitializeComponent();
            SetValue(ToolbarContentKey, stackPanel1.Children);
        }
    }
