    using System.Xml.Linq; 
    public Form1()
    {
        InitializeComponent();
        // Create an instance of the open file dialog box.
        // This is test purpose only. In production xml files will come from SQL Database.
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        // Set filter options and filter index.
        openFileDialog1.Title = "Please Choose XML File";
        openFileDialog1.Filter = "XML Files (.xml)|*.xml|All Files (*.*)|*.*";
        openFileDialog1.FilterIndex = 1;
        openFileDialog1.Multiselect = false;
        // Call the ShowDialog method to show the dialog box.
        openFileDialog1.ShowDialog();
        FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
        var data = XElement.Load(openFileDialog1.FileName);
        TreeNode treeNode = treeView1.Nodes.Add("Menu");
        LoadElements(data, treeNode);
        //Clear ListBox items
        ListBoxMain.Items.Clear();
        //Load ListBox First time
        foreach (TreeNode n in treeView1.Nodes)
        {
                ListBoxMain.Items.Add(n.Text);
        }
    }
