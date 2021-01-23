    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.FormClosing += formClosing;
            }
    
            private void formClosing(object sender, FormClosingEventArgs e)
            {
                comboBox1.SelectedIndexChanged -= comboBox1SelectedIndexChanged;
            }
    
            private void comboBox1SelectedIndexChanged(object sender, EventArgs e)
            {
                // your code
            }
        }
    }
