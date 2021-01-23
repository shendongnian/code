    if (tn.Checked)
    {       
        if(tn.Parent != null)
           tn.Parent.Nodes.Remove(tn);
        else 
           tv1.Nodes.Remove(tn);
    }
    if (tn.ChildNodes.Count > 0)
    {
         foreach (TreeNode tn1 in tn.ChildNodes)
         {
             Remove(tn1);
         }
    }
