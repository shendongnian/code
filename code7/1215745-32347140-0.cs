    public static TreeNode CloneWithoutChildren(this TreeNode node)
    {
        return new TreeNode(node.Text, node.ImageIndex, node.SelectedImageIndex)
        {
             Name = node.Name,
             ToolTipText = node.ToolTipText,
             Tag = node.Tag,
             Checked = node.Checked
        }
    }
