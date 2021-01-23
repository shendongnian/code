    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            Form1 form1;
            public Form2(Form1 nform1)
            {
                InitializeComponent();
                this.FormClosing +=  new FormClosingEventHandler(Form2_FormClosing);
                form1 = nform1;
                form1.Hide();
            }
            private void Form2_FormClosing(object sender, FormClosingEventArgs e)
            {
                //stops form from closing
                e.Cancel = true;
                this.Hide();
            }
            public string GetData()
            {
                return "The quick brown fox jumped over the lazy dog";
            }
        }
    }
    ​
