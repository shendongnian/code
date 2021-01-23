    public int Count<T>() where T : class
    {
        using (Connection.Lock())
        {
            var result = Connection.Table<T>().Count();
            return result;
        }
    }
