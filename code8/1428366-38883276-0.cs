    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var response = (OracleDataTableJsonResponse)value;
    
        using (var dbconn = new OracleConnection(response.ConnectionString))
        {
            dbconn.Open();
            ...
        }
    }
