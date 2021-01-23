    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    
        }
    
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }
    
        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            classx duration = new classx();
    
            MessageBox.Show("From " + comboBox1.Text + " to " + comboBox2.Text + " it takes around " + duration.Times());
        }
    }
