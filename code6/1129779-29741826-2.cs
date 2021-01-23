    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        using System.Collections;
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
              
                foreach (var result in this.Controls.OfType<ComboBox>())
                {
                    foreach (var values in Enumerable.Range(0, 10))
                    {
                        result.Items.Add(values);
                    }
    
                    result.Items.Add(result.Name);
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this.AddComboTextToList();
            }
    
            private void AddComboTextToList()
            {
                var comboEntries = this.FindComboBoxValues(this.Controls, "comboBox");
                foreach (var comboEntry in comboEntries)
                {
                    this.listBox1.Items.Add(comboEntry);
                }
            }
    
            private IEnumerable<object> FindComboBoxValues(Control.ControlCollection controls, string cmbName)
            {
                var cmbs = controls.OfType<ComboBox>().Where(x => x.Name.StartsWith(cmbName));
                var ret = new List<object>();
                foreach (var cmbBox in cmbs)
                {
                    ret.AddRange(cmbBox.Items.Cast<object>());
                }
    
                return ret;
            }
        }
    }
