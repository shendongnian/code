    public bool CheckUsableID<T>(int id, List<T> list) where T : IDomainObject
    {
        foreach(var item in list)
        {
            if (item.id == id)
            {
                return false;
            }
        }
            return true;
    }
