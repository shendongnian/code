        public void GenerateData(Action onDoneCallback)
        {
            try
            {
                var cmd = new SqlCommand("MyStoredProc", new SqlConnection("my DB connection string"));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Connection.Open();
                cmd.BeginExecuteNonQuery(
                    (IAsyncResult result) =>
                    {
                        cmd.EndExecuteNonQuery(result);
                        cmd.Dispose();
                        // Invoke the callback if it's provided, ignoring any errors it may throw.
                        var callback = result.AsyncState as Action;
                        if (callback != null)
                            callback.Invoke();
                    },
                    onUpdateCompleted);
            }
            catch (Exception ex)
            {
                // Handle errors...
            }
        }
