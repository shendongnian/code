    var rowCounts = new List<int>();
    var resultSets = new List<DataTable>();
    using (SqlConnection cn = new SqlConnection(connectionString))
    using (SqlCommand cmd = new SqlCommand(myScript, cn))
    {
        cmd.StatementCompleted += (sender, eventArgs) =>
        {
            rowCounts.Add(eventArgs.RecordCount);
        };
        cn.Open();
        using (var rd = cmd.ExecuteReader())
        {
            do
            {
                var table = new DataTable();
                table.Load(rd);
                resultSets.Add(table);
            } while (rd.NextResult());
        }
    }
    //rowCounts now holds all of the reported rowcounts
    //resultSets now holds all of the result sets returned.
