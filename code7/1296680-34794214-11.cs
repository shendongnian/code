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
            //Note that you should not use Text here, but selectedText
            //Note that now your classx takes input from comboBox2.SelectedText    
            MessageBox.Show("From " + comboBox1.SelectedText + " to " + comboBox2.SelectedText + " it takes around " + duration.Times(comboBox2.SelectedText));
        }
    }
