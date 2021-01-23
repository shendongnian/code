    private object Resolve(object parent, string path)
    {
        string[] paths = path.Split('.');
        foreach (string p in paths)
        {
            if (p.EndsWith("]"))
            {
                int start = p.IndexOf("[");
                string property = p.Substring(0, start);
                string index = p.Substring(start + 1, p.Length - start - 2);
                parent = GetFieldOrProperty(parent, property);
                if (parent == null)
                    return null;
                foreach (PropertyInfo info in parent.GetType().GetProperties())
                {
                    if (info.GetIndexParameters().Length < 1) continue;
                    parent = info.GetValue(parent, new object[] {int.Parse(index)});
                    break;
                }
            }
            else
            {
                parent = GetFieldOrProperty(parent, p);
                if (parent == null)
                    return null;
            }
        }
        return parent;
    }
