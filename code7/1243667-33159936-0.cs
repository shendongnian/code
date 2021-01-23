    public static IList<Tobj> GetLibList<Tobj, Tsvc>(Tsvc[] svcList) where Tobj : new()
    {
        IList<Tobj> objList = new List<Tobj>();
        foreach (Tsvc svcObject in svcList)
        {
            objList.Add((Tobj)Activator.CreateInstance(typeof(Tobj), svcObject));
        }
    
        return objList;
    }
    
    public static Tsvc[] GetSvcList<Tsvc, Tlib>(IList<Tlib> libList)
    {
        IList<Tsvc> svcList = new List<Tsvc>();
        foreach (Tlib libObj in libList)
        {
            // Check for null as GetMethod could throw null if method not found.
            svcList.Add((Tsvc)(typeof(Tlib).GetMethod("getSvcObject").Invoke(libObj, null)));
        }
    
        return svcList.ToArray<Tsvc>();
    }
