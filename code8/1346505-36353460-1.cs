    public partial class MyToolbarGroup : UserControl
    {
        public MyToolbarGroup()
        {
            InitializeComponent();
        }
        public string GroupText
        {
            get { return (string)GetValue(GroupTextProperty); }
            set { SetValue(GroupTextProperty, value); }
        }
        public static readonly DependencyProperty GroupTextProperty =
            DependencyProperty.Register("GroupText", typeof(string), typeof(MyToolbarGroup), new PropertyMetadata(null));
        public IEnumerable GroupItems
        {
            get { return (IEnumerable)GetValue(GroupItemsProperty); }
            set { SetValue(GroupItemsProperty, value); }
        }
        public static readonly DependencyProperty GroupItemsProperty =
            DependencyProperty.Register("GroupItems", typeof(IEnumerable), typeof(MyToolbarGroup), new PropertyMetadata(null));
    }
