        treeView1.CheckBoxes = true;
        TreeNode tn = new TreeNode("Node 1");
        TreeNode tn1 = new TreeNode("Node 11");
        TreeNode tn2 = new TreeNode("Node 12");
        tn1.Checked = true;
        tn2.Checked = true;
        tn.Nodes.Add(tn1);
        tn.Nodes.Add(tn2);
        treeView1.Nodes.Add(tn);
        // gray text:
        tn2.ForeColor = Color.Gray;
        // mark one node somehow:
        tn2.Tag = "X";
        // cancel changes for marked node:
        treeView1.BeforeCheck += (s, e) 
            => { if (e.Node.Tag != null && e.Node.Tag.ToString() == "X") e.Cancel = true; };
