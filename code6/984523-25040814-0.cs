    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private TreeNode _TN = null;
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _TN = treeView1.GetNodeAt(e.X, e.Y);
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_TN != null)
            {
                MessageBox.Show(_TN.Text);
            }
        }
    }
