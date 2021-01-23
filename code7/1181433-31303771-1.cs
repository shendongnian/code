    for (int i = 0; i < 1000; i++)
    {
        foreach (var elm in xdoc.Descendants("def"))
        {
            if (elm.Attribute("name").Value == def)
            {
                if (xelm!=null)
                    throw new InvalidOperationException();
                xelm = elm;
            }
        }
        if (xelm==null)
           throw new InvalidOperationException();
    }
    
