    [Route("api/GetData")]
    [HttpPost]
    public List<DataModel> GetData(int id, DateTime createDate)
    {
        var dataDb = new DataDb(SqlConnectionString);
        var result = dataDb .GetSalesData(id, createDate);
        return result;
    }
