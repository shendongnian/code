    using System;
    using System.Windows.Forms;
    
    namespace JsonTreeView
    {
        public partial class Form1 : Form
        {
    
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private string jsonFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TreeView.json");
    
            private void saveButton_Click(object sender, EventArgs e)
            {
               
                this.treeView1.Save(jsonFilePath);
            }
    
            private void clearButton_Click(object sender, EventArgs e)
            {
                this.treeView1.Nodes.Clear();
            }
    
            private void loadButton_Click(object sender, EventArgs e)
            {
                this.treeView1.Nodes.Clear();
                this.treeView1.Load(jsonFilePath);
            }
        }
    }
