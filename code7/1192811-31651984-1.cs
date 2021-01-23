        public List<IItemType> Items { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            IItemType i1 = new ItemType { ItemTypeCategoryId = 1, ItemTypeDetailId = 2, TypeName = "ItemType1" };
            IItemType i2 = new ItemTypeCategory { ItemTypeCategoryId = 2, CategoryName = "ItemTypeCategory1" };
            IItemType i3 = new ItemTypeDetail { ItemTypeDetailId = 3, ItemTypeDetailName = "ItemTypeDetail1" };
            Items = new List<IItemType>();
            Items.Add(i1);
            Items.Add(i2);
            Items.Add(i3);
        }
