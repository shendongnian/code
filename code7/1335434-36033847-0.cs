    private async Task<string> insertUpdateData(Person data, string path)
    {
            try
            {
                var db = new SQLiteAsyncConnection(path);
                if ( 0 != await db.InsertAsync(data))
                    await db.UpdateAsync(data);
                return "Single data file inserted or updated";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
    }
