    T Clone<T>(DbEntityEntry<T> entry)
        where T : class
    {
        var proxyCreationEnabled = this.Configuration.ProxyCreationEnabled;
        try
        {
            this.Configuration.ProxyCreationEnabled = false;
            var clone = (T)entry.CurrentValues.ToObject();
            Set(clone.GetType()).Add(clone);
            return clone;
        }
        finally
        {
            this.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }
    }
