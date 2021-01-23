    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Forms;
    
    namespace SOFAcrobatics
    {
        public partial class ComboBoxTesting : Form
        {
            public ComboBoxTesting()
            {
                this.InitializeComponent();
            }
    
            private void ComboBoxTesting_Load(object sender, EventArgs e)
            {
                List<String> items = new List<String>()
                {
                    "0 minutes",
                    "1 minutes",
                    "2 minutes"
                };
    
                foreach (String item in items)
                {
                    this.comboBox1.Items.Add(item);
                }
    
                this.comboBox1.SelectedIndex = 0;
            }
        }
    }
