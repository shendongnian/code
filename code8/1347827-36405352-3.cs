    public partial class Class2 : Form
    {
        private IEnumerable<ISelectable> selectableItems;
    
        public Class2()
        {
            InitializeComponent();
        }
    
        public Class2(string exportText, IEnumerable<ISelectable> list) : this()
        {
            this.selectableItems = list;
        }
    
        public ISelectable SelectedItem { get; set; }
        public List<ISelectable> SelectedItems { get; set; }
    
        private void Class2_Load(object sender, EventArgs e)
        {
            foreach (ISelectable item in selectableItems)
            {
                //System.Diagnostics.Debug.Print(item.DisplayName);
                System.Diagnostics.Debug.Print(item.ToString());
            }
        }
    }
