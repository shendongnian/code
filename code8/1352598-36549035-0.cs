    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace SOFAcrobatics
    {
        public partial class Dividers : Form
        {
            public Dividers()
            {
                InitializeComponent();
    
                this.listBox1.SelectionMode = SelectionMode.MultiSimple;
    
                for (Int32 i = 1 ; i <= 30 ; i++)
                {
                    this.listBox1.Items.Add(i);
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Int32 n = Int32.Parse(this.textBox1.Text);
    
                List<Int32> indexes = new List<Int32> ();
    
                Int32 counter = 0;
    
                for (Int32 i = 0 ; i < this.listBox1.Items.Count ; i++)
                {
                    if ((((Int32)this.listBox1.Items[i]) % n) == 0)
                    {
                        indexes.Add(i);
                    }
                }
    
                for (Int32 i = 0 ; i < indexes.Count ; i++)
                {
                    this.listBox1.SetSelected(indexes[i], true);
                }
    
                this.label1.Text = (indexes.Count + 1).ToString();
            }
        }
    }
