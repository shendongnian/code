    internal void SaveOwner(Owner o)
    {
        using(StreamWriter w = new StreamWriter(path, true))
        {
           if (o != null)
           {
              w.WriteLine(o.ToFileString());
           }
        }
    }
