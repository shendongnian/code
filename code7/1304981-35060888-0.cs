    public partial class frmTestGirdBinding : Form
    {
        CustomDataCollection cdata = new CustomDataCollection();
        Random rnd = new Random();
        public frmTestGirdBinding()
        {
            InitializeComponent();
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
        }
    
        private void frmTestGirdBinding_Load(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = cdata;
            dataGridView1.DataSource = bindingSource1;            
    
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cdata.Count; i++)
            {
                cdata[i].Reading = (float)rnd.NextDouble();
            }
            dataGridView1.Refresh(); //without this all rows are not updating
        }
    
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //InVisible the rows
            dataGridView1.Rows[2].Visible = false;
            dataGridView1.Rows[3].Visible = false;
        }
    }
