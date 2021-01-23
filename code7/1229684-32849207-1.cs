    public partial class PeopleListView : UserControl, IPeopleListView
    {
        public PeopleListView()
        {
            InitializeComponent();
        }
        public DataGridViewRow GetSelectedRow()
        {
            return PeopleGridView.CurrentRow;
        }
        public void SetDataSource(BindingSource bSource)
        {
            PeopleGridView.AutoGenerateColumns = false;
            PeopleGridView.DataSource = bSource;
        }
        private void PeopleGridView_SelectionChanged(object sender, EventArgs e)
        {
            SelectionChanged?.Invoke(new object(), new EventArgs());
        }
        public event EventHandler SelectionChanged;
    }
