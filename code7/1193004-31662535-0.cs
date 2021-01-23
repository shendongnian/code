    public void Apply(EntitySet entitySet, DbModel model)
    {
        string name = entitySet.Name;
        if (entitySet.ElementType.Name != null)
        {
            try
            {
                foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (Type t in a.GetTypes())
                    {
                        if (t.Name == entitySet.ElementType.Name)
                        {
                            if (typeof(ILookupValue).IsAssignableFrom(t)) { entitySet.Schema = "lu"; }
                        }
                    }
                } 
            }
            catch(Exception e)
            {
                Debug.Print(e.ToString());
            }
        }
    }
