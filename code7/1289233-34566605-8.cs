    [Route("api/test/{custName}")]
    public IEnumerable<string> Post([FromUri]string custName)
    {
        try
        {
            names.Add(custName);
            return names;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
