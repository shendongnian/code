    System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(TreeViewData));
    System.IO.FileStream file = new System.IO.FileStream(strFilename, FileMode.Open);
    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(file);
    TreeViewData treeData = (TreeViewData)ser.Deserialize(reader);
    treeData.PopulateTree(TreeView1);
