    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            this.Load += Test_Load;
        }
        private void Test_Load(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc1 = new XmlDocument();
                doc1.Load("file1.xml");
                XmlDocument doc2 = new XmlDocument();
                doc2.Load("file2.xml");
                trvLeft.Nodes.Clear();
                trvRight.Nodes.Clear();
                trvLeft.Nodes.Add(new TreeNode("File 1"));
                trvRight.Nodes.Add(new TreeNode("File 2"));
                TreeNode tlNode = new TreeNode();
                TreeNode trNode = new TreeNode();
                tlNode = trvLeft.Nodes[0];
                trNode = trvRight.Nodes[0];
                AddNode(doc1.DocumentElement, doc2.DocumentElement, tlNode, trNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            var childrensLeft = trvLeft.Nodes[0].Nodes[0].Nodes;
            var childrensRight = trvRight.Nodes[0].Nodes[0].Nodes;
            for (int i = 0; i < Math.Min(childrensLeft.Count, childrensRight.Count); i++)
            {
                if (childrensRight[i].Text != childrensLeft[i].Text)
                {
                    //childrensLeft[i].ForeColor = Color.Red;
                    //childrensRight[i].ForeColor = Color.Red;
                    childrensLeft[i].Nodes.Add("Something to left");
                    childrensRight[i].Nodes.Add("Something to right");
                }
            }
            trvLeft.ExpandAll();
            trvRight.ExpandAll();
        }
        private void AddNode(XmlNode leftXmlNode, XmlNode rightXmlNode, TreeNode leftNode, TreeNode rightNode)
        {
            //XmlNode xNode;
            TreeNode tlNode;
            TreeNode trNode;
            XmlNodeList lnodeList;
            XmlNodeList rnodeList;
            int i;
            if (leftXmlNode.HasChildNodes && rightXmlNode.HasChildNodes)
            {
                lnodeList = leftXmlNode.ChildNodes;
                rnodeList = rightXmlNode.ChildNodes;
                for (i = 0; i <= Math.Min(lnodeList.Count, rnodeList.Count) - 1; i++)
                {
                    var lNode = leftXmlNode.ChildNodes[i];
                    var rNode = rightXmlNode.ChildNodes[i];
                    leftNode.Nodes.Add(new TreeNode(lNode.Name));
                    tlNode = leftNode.Nodes[i];
                    rightNode.Nodes.Add(new TreeNode(rNode.Name));
                    trNode = rightNode.Nodes[i];
                    AddNode(lNode, rNode, tlNode, trNode);
                }
            }
            else
            {
                leftNode.Text = (leftXmlNode.OuterXml).Trim();
                rightNode.Text = (rightXmlNode.OuterXml).Trim();
            }
        }
    }
