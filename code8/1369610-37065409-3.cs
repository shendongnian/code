    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void label1_Click(object sender, EventArgs e)
            {
                label1.Text = "Something";
            }
        }
    }
