    static object syncRoot = "";
    ...
    void SaveOwner(Owner o)
    {
        lock (syncRoot)
        {
            using (StreamWriter w = new StreamWriter(path, true))
            {
                if (o != null)
                    w.WriteLine(o.ToFileString());
            }
        }
    }
