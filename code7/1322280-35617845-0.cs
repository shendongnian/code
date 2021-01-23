    List<MyClass> mcopy = new List<MyClass>[marraylist.GetUpperBound(0)+1,marraylist.GetUpperBound(1)+1];
    for (int i = 0; i < marraylist.GetUpperBound(0); ++i)
    {
        for (int j = 0; j < marraylist.GetUpperBound(1); ++j)
        {
            mcopy[i,j] = marraylist[i,j];
        }
    }
