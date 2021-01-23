    private Event nvcToCoreEvent(NameValueCollection nvc) {
        Event e = new Event();
        foreach (string kvp in nvc.AllKeys) {
            string[] keys = kvp.Substring(0, kvp.Length - 1).Replace("coreEvent[", "").split(new string[] { "][" });
            PropertyInfo pi = e.GetType().GetProperty(keys[0], BindingFlags.Public | BindingFlags.Instance);
            for (int i = 1; i < keys.Length; i++)
                pi = pi.PropertyType.GetProperty(keys[i], BindingFlags.Public | BindingFlags.Instance);
            
            if (pi != null) {
                pi.SetValue(e, nvc[kvp], null);
            }
        }
        return e;
    }
