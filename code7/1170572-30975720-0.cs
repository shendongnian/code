    public void WriteProps<T>()
    {
        foreach (System.Reflection.PropertyInfo prop in typeof(T).GetProperties())
        {
            Response.Write(prop.Name + "<BR>")
        } 
    }
    ...
    WriteProps<List<Category>>();
