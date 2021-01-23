    public List<Category> getRootNodes()
    {
       List<Category> rootNodes = new List<Category>();
       foreach (Category c in categories)
       {
           if (c.ParentID == 0) rootNodes.Add(c);
       }
       return rootNodes;
    }
