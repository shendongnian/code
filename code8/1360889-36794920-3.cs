    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }
        [Editor(typeof(MyColumnEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DataGridViewColumnCollection Columns
        {
            get { return this.dataGridView1.Columns; }
        }
    }
