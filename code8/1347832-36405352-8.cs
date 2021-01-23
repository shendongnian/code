    public partial class Class2<T> : Form where T : ISelectable
    {
        private IEnumerable<ISelectable> selectableItems;
    
        public Class2()
        {
            InitializeComponent();
        }
    
        public Class2(string exportText, IEnumerable<T> list) : this()
        {
            this.selectableItems = list;
        }
    
        public T { get; set; }
        public List<T> SelectedItems { get; set; }
    
        private void Class2_Load(object sender, EventArgs e)
        {
            foreach (ISelectable item in selectableItems)
            {
                //System.Diagnostics.Debug.Print(item.DisplayName);
                System.Diagnostics.Debug.Print(item.ToString());
            }
        }
    }
