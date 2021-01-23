    public int Delete<T>(object pocoOrPrimaryKey)
    {
        if (pocoOrPrimaryKey.GetType() == typeof(T))
            return Delete(pocoOrPrimaryKey);
        var pd = PocoDataFactory.ForType(typeof(T));
        return Delete(pd.TableInfo.TableName, pd.TableInfo.PrimaryKey, null, pocoOrPrimaryKey); // This is the method your code calls
    }
