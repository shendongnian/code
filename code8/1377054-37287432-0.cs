    public static List<T> get<T>() where T : class
    {
        var type = typeof(T);
        var prop = type.GetProperty("Activo")
        if (prop!=null)
        {
            return (from c in context.Set<T>().AsQueryable()
                where prop.GetValue(c, null)=="xyz123"
                select c).ToList();
        }
        else
        {
            return (from c in context.Set<T>().AsQueryable()
                select c).ToList();
        }         
    }
