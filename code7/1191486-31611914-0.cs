	[WebMethod]
    public string Querry(StaticClass query)
    {
        string SelectDataQuerry = query.Querry;
        return SelectDataQuerry ;
    }
