    private void TestExcelRange(string[] tagCollection)
    {
        string DellTag = null;
        int maxGroupAmount = 90;
        var chunks = GetChunks(tagCollection, maxGroupAmount);
        foreach (IEnumerable<string> chunk in chunks)
        {
            //process in groups of 90      
        }            
    }
