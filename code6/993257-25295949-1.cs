    async Task<List<notes>> query(string sqlstring, SQLiteConnection con)
    {
        var p = await con.QueryAsync<notes>(sqlstring);
        //Or, if there is no asynchronous query method
        //var p = await Task.Run(() => con.Query<notes>(sqlstring));
        await Task.Delay(5000);
        MessageBox.Show(p[0].Data);
        return p;
    }
