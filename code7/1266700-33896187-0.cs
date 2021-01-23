    private TreeNode Append(TreeNode parent, string text)
    {
        TreeNode newNode;
        if (parent != null)
        {
            newNode = parent.Nodes.Add(text);
            newNode.Tag = parent.Tag + "\\{" + text + "}";
        }
        else
        {
            newNode = treeView1.Nodes.Add(text);
            newNode.Tag = "{" + text + "}";
        }
        return newNode;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        TreeNode chapter1 = Append(null, "chapter1");
        Append(chapter1, "sec1");
        Append(chapter1, "sec2");
        Append(chapter1, "sec3");
        TreeNode chapter2 = Append(null, "chapter2");
        Append(chapter2, "sec1");
        Append(chapter2, "sec2");
        Append(chapter2, "sec3");
        TreeNode chapter3 = Append(null, "chapter3");
        Append(chapter3, "sec1");
        Append(chapter3, "sec2");
        Append(chapter3, "sec3");
    }
    private void IncludeChapterAndSections(TreeNode treeNode, StringBuilder sb)
    {
        TreeNodeCollection children = treeNode != null ? treeNode.Nodes : treeView1.Nodes;
        if (treeNode != null)
        {
            sb.AppendFormat("\\include {0}", treeNode.Tag.ToString());
            sb.AppendLine();
        }
        foreach (TreeNode child in children)
        {
            IncludeChapterAndSections(child, sb);
        }
    }
    private void button3_Click(object sender, EventArgs e)
    {
        var header = File.ReadAllText(@"C:\dir\header.tex");
        var footer = File.ReadAllText(@"C:\dir\footer.tex");
        var sb = new StringBuilder();
        sb.AppendLine(header);
        IncludeChapterAndSections(null, sb);
        sb.AppendLine(footer);
        File.WriteAllText(@"C:\dir\final.tex", sb.ToString());
    }
