    public object this[string key]
    {
        get
        {
            object o;
            return vars.TryGetValue(key, out o) ? o : null;
        }
        set
        {
            if (value != null)
            {
                vars[key] = value;
            }
            else
            {
                vars.Remove(key);
            }
        }
    }
