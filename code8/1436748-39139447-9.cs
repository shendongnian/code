    public void BindMyData()
    {
        IEnumerable<Dictionary<string, object>> patients = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(resultAsString);
        datagrid.DataSource = patients.ToDataTable();
    }
