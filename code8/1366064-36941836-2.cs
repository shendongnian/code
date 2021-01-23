    public async Task<string[]> getSplittedClassName()
    {
        HttpResponseMessage response = await httpClient.GetAsync(url);
        return parser.breakdownClassName(response);
    }
