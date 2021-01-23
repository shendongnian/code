    public partial class OtherForm : Form
    {
        DataTable table;
        public OtherForm(DataTable value)
        {
            InitializeComponent();
            
            //get passed data and put it in some member variable for next usages
            table = value;
            //Bind data to other grid or do other things here or in Form Load event
            this.dataGridView1.DataSource = table;
        }
    }
