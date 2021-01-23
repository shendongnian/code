    public static Task<int> ExecuteNonQueryAsync(this SqlCommand sqlCommand)
    {
      var tcs = new TaskCompletionSource<int>();
      sqlCommand.BeginExecutedNonQuery(result =>
      {
        tcs.SetResult(sqlCommand.EndExecutedNonQuery());
      });
      return await tcs.Task;
    }
