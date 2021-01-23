    public partial class Form1 : Form
    {
        // form level variables to hold current node and prior node
        TreeNode _priorNode, _currentNode;
    
        public Form1()
        {
            InitializeComponent();
        }
        // stores the prior node (based on current node) after node select    
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            String textToSave;
            String fileName;
            System.IO.StreamWriter writer;
    
            if (_currentNode != null)
            {
                _priorNode = _currentNode;
            }
            _currentNode = e.Node;
            if (_priorNode != null)
            {
                textToSave = textBox1.Text;
                fileName = _priorNode.FullPath;
                writer = new System.IO.StreamWriter(fileName);
                writer.Write(textToSave);
                writer.Close();
            }
        }
    }
