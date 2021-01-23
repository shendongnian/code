    public partial class ItemsEditor : UserControl
    {
        #region Items
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(
                "Items",
                typeof(IEnumerable<Item>),
                typeof(ItemsEditor),
                new UIPropertyMetadata(null));
        public IEnumerable<Item> Items
        {
            get { return (IEnumerable<Item>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        #endregion  
        #region AddItem
        public static readonly DependencyProperty AddItemProperty =
            DependencyProperty.Register(
                "AddItem",
                typeof(ICommand),
                typeof(ItemsEditor),
                new UIPropertyMetadata(null));
        public ICommand AddItem
        {
            get { return (ICommand)GetValue(AddItemProperty); }
            set { SetValue(AddItemProperty, value); }
        }
        #endregion          
        #region RemoveItem
        public static readonly DependencyProperty RemoveItemProperty =
            DependencyProperty.Register(
                "RemoveItem",
                typeof(ICommand),
                typeof(ItemsEditor),
                new UIPropertyMetadata(null));
        public ICommand RemoveItem
        {
            get { return (ICommand)GetValue(RemoveItemProperty); }
            set { SetValue(RemoveItemProperty, value); }
        }        
        #endregion  
        public ItemsEditor()
        {
            InitializeComponent();
        }
    }
