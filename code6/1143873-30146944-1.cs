    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            private void Form2_Load(object sender, EventArgs e)
            {
    
            }
    
            public string theVariable //This is your method to pass the string to the new form (Form2)
            {
                get { return textBox1.Text; }
                set { textBox1.Text = value; }
            }
        }
    }
