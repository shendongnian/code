    public static PropKV LoadFromDB(string Key)
    {
        PropKV result = null;
        using (var db = new ItemModelContainer())
        {
            result = db.Find(key);
        }
        return result;
    }
