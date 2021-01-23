    public static void FindAndAssignComponent<T>(string name) where T : Component
    {
        GameObject g = GameObject.Find(name);
        if (g == null)
            throw new ObjectNotFoundException(String.Format("GameObject '{0}' not found in hierarchy!", name));
        g.AddComponent<T>();
    }
