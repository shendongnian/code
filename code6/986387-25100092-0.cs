    public TDest ReflectionCopy<TDest>(object srcVal)
        where TDest : class, new()
    {
        if (srcVal == null) { return null; }
        TDest dest = new TDest();
        var props = srcVal.GetType().GetProperties();
        foreach (PropertyInfo p in props)
        {
            PropertyInfo objPf = typeof(TDest).GetProperty(p.Name);
            if (objPf != null)
            {
                if (objPf.PropertyType.IsGenericType && typeof(IEnumerable).IsAssignableFrom(objPf.PropertyType))
                {
                    var destCollType = objPf.PropertyType.GenericTypeArguments[0];
                    var recurse = this.GetType().GetMethod("ReflectionCopy").MakeGenericMethod(destCollType);
                    IEnumerable srcList = (IEnumerable)p.GetValue(srcVal);
                    IList destlst = (IList)Activator.CreateInstance(objPf.PropertyType);
                    foreach(var srcListVal in srcList)
                    {
                        var destLstVal = recurse.Invoke(this, new object[1] { srcListVal });
                        destlst.Add(destLstVal);
                    }
                    objPf.SetValue(dest, destlst);
                    continue;
                }
    
                if (p.PropertyType == objPf.PropertyType)
                {
                    objPf.SetValue(dest, p.GetValue(srcVal));
                }
            }
        }
        return dest;
    }
