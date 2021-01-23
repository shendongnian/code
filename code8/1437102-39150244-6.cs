    public async Task<List<MyData>> GetDataAsync(bool IncludeDeleted = false)
    {
        List<MyData> temp = new List<MyData>();
        using (var reader = await GetReaderAsync("GetData"))
        {
            while (reader.Read())
            {
                temp.Add(FillData(reader));
            }
        }
        return temp;
    }
