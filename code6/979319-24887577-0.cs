        protected string RadioButtonGroupName { get; set; }
        private TreeViewItem createCheckBoxInTree(string content, TreeView tree)
        {
            TreeViewItem item = new TreeViewItem()
            {
                Header = new CheckBox()
                {
                    Content = content
                }
            };
            tree.Items.Add(item);
            return item;
        }
        private void createRadioButtonsChildren(string content, TreeViewItem item)
        {
            TreeViewItem childRadio = new TreeViewItem()
            {
                Header = new RadioButton()
                {
                    Content = content,
                    GroupName = RadioButtonGroupName,
                }
            };
            item.Items.Add(childRadio);
        }
        public MainWindow()
        {
            InitializeComponent();
            RadioButtonGroupName = "MyFirstGroup";
            TreeViewItem parent = createCheckBoxInTree("parent", tree);
            createRadioButtonsChildren("child1", parent);
            createRadioButtonsChildren("child2", parent);
            createRadioButtonsChildren("child3", parent);
        }
