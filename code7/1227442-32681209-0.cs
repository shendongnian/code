    public static Component FindAndAssignComponent<T>(string name) where T : Component
    {
        GameObject g = GameObject.Find(name);
        if (g != null) return g.GetComponent<T>();
        return null;
    }
