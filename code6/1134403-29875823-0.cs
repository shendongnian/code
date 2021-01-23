    public static List<T> FindControls<T>(Control container, bool dig) where T : Control
    {
        List<T> retVal = new List<T>();
        foreach (Control item in container.Controls)
        {
            if (item is T)
                retVal.Add((T)item);
            if (dig && item.Controls.Count > 0)
                retVal.AddRange(FindControls<T>(item, dig));
        }
        return retVal;
    }
