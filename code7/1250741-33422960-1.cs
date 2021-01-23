    public static TModel ObjectToModel<TModel>(this object source, string[] propsToExclude = null)
            where TModel : new()
    {
       var dest = new TModel();
       CopyPropertiesToObject(source, dest, propsToExclude);
       return dest;
    }
    
    
    public static bool CopyPropertiesToObject<TU>(this object source, TU dest, string[] propsToExclude = null)
    {
       propsToExclude = propsToExclude ?? new string[0];
       var sourceProps = source.GetType().GetProperties().Cast<PropertyInfo>();
       var destProps = typeof(TU).GetProperties().Cast<PropertyInfo>().Where(x => x.CanWrite && sourceProps.Any(s => s.Name == x.Name) && !propsToExclude.Any(e => e == x.Name));
       // code
    }
