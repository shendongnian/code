    static void Main()
    {
        var v1Task = Connect();
        var v2Task = Connect();
        var results = Task.WhenAll(v1Task, v2Task);
        var v1 = results.Result[0];
        var v2 = results.Result[1];
    }
    static async Task<int> Connect()
    {
        int v;
        try
        {
            using (var con2 = new OleDbConnection("Provider=MSDAORA.1;Data Source=db2:1521;Persist Security Info=True;Password=password;User ID=username"))
            {
                await con2.OpenAsync();
                v = 1;
                con2.Close();
            }
        }
        catch (Exception)
        {
            v = 0;
        }
        return v;
    }
