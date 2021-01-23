    public static async Task ExecuteInParallel(SqlCommand[] commands)
    {
        var sqlTasks = commands.Select(c => ExecuteNonQueryAsync());
        await Task.WhenAll(sqlTasks);
    }
