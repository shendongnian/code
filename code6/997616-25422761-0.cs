    TreeNode node = null;
    while ((line = reader.ReadLine()) != "end")
    {
        if (line.Contains("id"))
        {
             ...
             // Note how you don't need to call ToString() on the result of Substring
             node = Form1.Instance.treeView1.Noodes[0].Nodes.Add("Picture: " + 
                 str.Substring(startIndex, endIndex - startIndex));
        }
        else if (line.Contains("ani = "))
        {
            ...
            node.Add(...);
        }
    }
