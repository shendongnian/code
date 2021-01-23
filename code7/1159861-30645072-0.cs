    List<string> lst = new List<string>();
    string item;
    
    for (i=2; i<2001; i++)
    {
        item = ws.cells[i,3];
        if(!lst.Contains(item))
        {
            lst.Add(item);
        }
    }
