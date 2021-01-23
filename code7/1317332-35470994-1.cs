    private async Task<string> ParseOne(int fileId)
    {
        string wholeFile = await ReadFile(fileId);
        string parsedData = ParseFile(wholeFile);
        string outputFileName = await SaveParsed(parsedData);
        return outputFileName;
    }
    
    public async Task<JsonResult> Parse(string idFiles)
    {
        int[] idf = getIds(idFiles); 
    
        var doneFiles = await Task.WhenAll(idf.Select(id => ParseOne(id)));
    
        return  Json(new { doneFiles });
    }
