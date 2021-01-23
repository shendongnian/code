    using System;
    using System.Windows.Forms;
    namespace TreeViewExample
    {
        public partial class NodeNameDialog : Form
        {
            public NodeNameDialog()
            {
                InitializeComponent();
            }
        
            private void btnOk_Click(object sender, EventArgs e)
            {
                NodeName = txtNodeName.Text ?? string.Empty;
                DialogResult = DialogResult.OK;
            } 
            private void btnCancel_Click(object sender, EventArgs e)
            {
                DialogResult = DialogResult.Cancel;
            }
        
            public string NodeName { get; set; }
        }
    }
