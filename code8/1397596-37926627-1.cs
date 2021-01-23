    public T GetSingle(int id)
    {
        var propertyInfos = typeof(T).GetProperties().Where(property => property.GetCustomAttributes<MyIdAttribute>().Count() > 0).ToList();
        if (propertyInfos.Any())
        {
            foreach(T current in GetAll())
            {
                object value = propertyInfos[0].GetValue(current);
                if(value == id)
                {
                    return current;
                }
            }
        }
    }
    
