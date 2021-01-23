    [Route("api/GetData/")]
    [HttpPost]
    public List<DataModel> GetData([FromBody] getDataParameters)
    {
        var dataDb = new DataDb(SqlConnectionString);
        var result = dataDb .GetSalesData(getDataParameters.id, getDataParameters.createDate);
        return result;
    }
