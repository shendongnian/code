    public partial class Form1 : Form
    {
        protected classzz myClass;
        public Form1()
        {
            InitializeComponent();
            myClass = new classzz();
            comboBox1.DataSource = myClass.Places;
            comboBox2.DataSource = myClass.Kilometers;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           label1.Text = myClass.ShowValues(comboBox1.SelectedValue.ToString(), Int32.Parse(comboBox2.SelectedValue.ToString()));
        }
    }
