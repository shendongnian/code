    public void BindMyData()
    {
        IEnumerable<Dictionary<string, object>> patients = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(resultAsString);
        // if this works, i'm not sure:
        datagrid.DataSource = patients;
    }
