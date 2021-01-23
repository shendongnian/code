    PTree attachPoint = chain.Find(x => x.Val == RTree.Val);
    if (attachPoint != null)
    {
        foreach (var c in attachPoint.Childs)
        {
            RTree.Left.Childs.Add(c);
        }
        // Here you either have to find the attachPoint parent and
        // replace attachPoint with RTree in parent.Childs,
        // or make attachPoint.Childs to be RTree.Childs as below
        attachPoint.Childs.Clear();
        foreach (var c in RTree.Childs)
        {
            attachPoint.Childs.Add(c);
        }
    }
    else
    {
        RTree.Left.Childs.Add(root);
        root = RTree;
    }
