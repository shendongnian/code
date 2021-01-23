    private Lazy<List<object>> m_objects = new Lazy<List<object>>();
    public List<object> GetList()
    {
        return m_objects.Value;
    }
