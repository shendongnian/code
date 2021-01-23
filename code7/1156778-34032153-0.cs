    private static void Main() {
        var sw = new Stopwatch();
        sw.Start();
        Task.WaitAll(
            GetDelayCommand().ExecuteNonQueryAsync(),
            GetDelayCommand().ExecuteNonQueryAsync(),
            GetDelayCommand().ExecuteNonQueryAsync(),
            GetDelayCommand().ExecuteNonQueryAsync(),
            GetDelayCommand().ExecuteNonQueryAsync(),
            GetDelayCommand().ExecuteNonQueryAsync(),
            GetDelayCommand().ExecuteNonQueryAsync(),
            GetDelayCommand().ExecuteNonQueryAsync(),
            GetDelayCommand().ExecuteNonQueryAsync(),
            GetDelayCommand().ExecuteNonQueryAsync(),
            GetDelayCommand().ExecuteNonQueryAsync(),
            GetDelayCommand().ExecuteNonQueryAsync());
        sw.Stop();
        Console.WriteLine(sw.Elapsed.Seconds);
    }
    private static DbCommand GetDelayCommand() {
        var connection = new MySqlConnection (...);
        connection.Open();
        var cmd = connection.CreateCommand();
        cmd.CommandText = "SLEEP(5)";
        cmd.CommandType = CommandType.Text;
        return cmd;
    }
