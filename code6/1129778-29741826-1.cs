    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this.AddComboTextToList();
            }
    
            private void AddComboTextToList()
            {
                var comboEntries = this.FindComboBoxValues(this.Controls, "comboBox").ToList();
                comboEntries.ForEach(f => this.listBox1.Items.Add(f));
            }
    
            private IEnumerable<string> FindComboBoxValues(Control.ControlCollection controls, string cmbName)
            {
                return controls.OfType<ComboBox>().Where(x => x.Name.StartsWith(cmbName)).Select(s => s.Text);
            }
        }
    }
