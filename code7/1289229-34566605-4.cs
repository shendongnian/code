    [Route("api/test/{custName}")]
    public IEnumerable<string> Post([FromBody]ViewModel viewModel)
    {
        try
        {
            names.Add(viewModel.custName);
            return names;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
