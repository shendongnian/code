    public List<Rectangle> GetQuads()
    {
        var list = new List<Rectangle> ();
        AddQuads(list);
        return list;
    }
    
    private void AddQuads(List<Rectangle> list)
    {
        if(this.HasChilds)
        {
            foreach(QuadTree node in this.Nodes)
            {
                node.AddQuads(list);
            }
        }
        list.Add(this.Bounds);
    }
