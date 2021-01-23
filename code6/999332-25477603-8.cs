    if (tn.Checked)
    {       
        if(tn.Parent != null)
           tn.Parent.ChildNodes.Remove(tn);
        else 
           tv1.Nodes.Remove(tn);
    }
    else if (tn.ChildNodes.Count > 0)
    {      
         for(int i=0; i < tn.ChildNodes.Count; i++)
         {
             Remove(tn.ChildNodes[i]);
         }
    }
