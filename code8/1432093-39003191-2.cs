    public partial class ExampleForm : Form
    {
        public ExampleForm()
        {
            InitializeComponent();
            comboBox1.Enabled = true;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox1.OnSelectedIndexChanged += comboBox1_OnSelectedIndexChanged;
            comboBox2.OnSelectedIndexChanged += comboBox2_OnSelectedIndexChanged;
            comboBox3.OnSelectedIndexChanged += comboBox3_OnSelectedIndexChanged;
        }
        void comboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            comboBox2.Enabled = true;
        }
        void comboBox2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
            comboBox3.Enabled = true;
        }
        void comboBox3_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox3.Enabled = false;
        }
    }
