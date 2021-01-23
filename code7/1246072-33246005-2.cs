    public List<string> GetApplicationNames()
    {
        using (ComData.Entities db = new ComData.Entities())
        {
            return db.GET_ALL_APPS();                 
        }
    }
