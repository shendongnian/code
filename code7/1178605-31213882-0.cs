    public static Task<bool> SuccessAsync()
    {
        return 0 < await ExecuteAsync("DELETE FROM Table WHERE Id = 12");
    }
    public static async Task<int> ExecuteAsync(string sql)
    {
        using (var con = Connection)
        {
            con.Open();
            return await con.ExecuteAsync(sql);
        }
    }
