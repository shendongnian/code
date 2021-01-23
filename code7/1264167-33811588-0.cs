    public static void SetDateTimeIfNotSet(object p)
    {
        Type t = p.GetType();
        t.GetProperties()
            .Where(c=>c.PropertyType.IsClass || c.PropertyType == typeof(DateTime))
            .ToList().ForEach(c =>
        {
            object child = c.GetValue(p);
            if (c.PropertyType == typeof (DateTime))
            {
                if((DateTime)child == default(DateTime))
                c.SetValue(p, DateTime.Now);
            }
            else
            {                    
                if(child!=null)
                    SetDateTimeIfNotSet(c.GetValue(p));
            }
        });
    }
