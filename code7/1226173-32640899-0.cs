    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                comboBox1.SelectedIndexChanged +=comboBox1_SelectedIndexChanged;
            }
    
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
    
            }
        }
