    public partial class ExampleForm : Form
    {
        public ExampleForm()
        {
            InitializeComponent();
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox1.SelectionChangeCommitted += comboBox1_SelectionChangeCommitted;
            comboBox2.SelectionChangeCommitted += comboBox2_SelectionChangeCommitted;
            comboBox3.SelectionChangeCommitted += comboBox3_SelectionChangeCommitted;
        }
        void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
        }
        void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            comboBox3.Enabled = false;
        }
        void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
        }
    }
