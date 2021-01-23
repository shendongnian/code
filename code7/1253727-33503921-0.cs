    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                //var clientBindingSource = new BindingSource(); // Set in designer
                clientBindingSource.Add(new Client {Id = 1, Name = "Rob"});
                clientBindingSource.Add(new Client {Id = 2, Name = "Tim"});
                //clientDataGridView.DataSource = clientBindingSource; // Set in designer
            }
            private void button1_Click(object sender, EventArgs e)
            {
                // Updating the binding source updates the grid            
                clientBindingSource.Add(new Client {Id = 3, Name = "Kathy"});
                //clientBindingSource.EndEdit(); // May or may not have to end edit to see results
            }
        }
    }
