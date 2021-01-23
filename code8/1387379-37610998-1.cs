    public string DataTableToJsonWithJsonNet(DataTable objDataTable) 
    {
       string jsonString=string.Empty;
       jsonString = JsonConvert.SerializeObject(objDataTable);
       return jsonString;
    }
