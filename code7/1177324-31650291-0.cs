    public async Task<DataTable> GetResultAsync(SomeVariable someVariable)
    {
        var task = Task.Run( () =>
        {
            DataTable matchedData = new DataTable();
            matchedData = DoTask(someVariable);
            return matchedData;
        }
    }
