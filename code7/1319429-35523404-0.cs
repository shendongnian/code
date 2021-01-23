    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            Form2 form2;
            public Form1()
            {
                InitializeComponent();
                form2 = new Form2(this);
            }
            private void button1_Click(object sender, EventArgs e)
            {
                form2.Show();
                string results = form2.GetData();
            }
        }
    }
