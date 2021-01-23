    [HttpGet("GetLatestItems/{num}")]
    public IEnumerable<string> GetLatestItems(int num)
    {
        return new string[] { "test", "test2" };
    }
