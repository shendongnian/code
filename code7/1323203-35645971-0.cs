    public List<TreeNode> FindIndex(TreeNodeCollection nodes, List<TreeNode> list) {
    int idx;
    foreach (TreeNode Node in nodes)
    {
        if (Node.Text == "test")
        {
            idx = Node.Index;
            list.Add(Node);
        }
        else
        {
            MessageBox.Show("This XML file does not contain any node with name \"test\"!");
            break;
        }
        FindIndex(Node.Nodes, list);
    }
    return list;
}
