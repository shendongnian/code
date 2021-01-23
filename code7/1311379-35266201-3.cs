    void SetNode(TreeNode node, bool enabled)
    {
        node.ForeColor = enabled ? SystemColors.ControlText : Color.Gray;
        node.Tag = enabled ? null : "X";
    }
