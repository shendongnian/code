    if (File.Exists(fileName))
    {
        TruncateTempTable(connection);
        DataTable newRecs = new DataTable();
        newRecs.Columns.Add("per_nummer", typeof (string));
        newRecs.Columns.Add("per_pid", typeof(string));
        newRecs.Columns.Add("per_name", typeof(string));
        using (TextReader tr = File.OpenText(fileName))
        {
            while (tr.Peek() > 0)
            {
                string theLine = tr.ReadLine();
                DataRow newRow = newRecs.NewRow();
                newRow["per_nummer"] = theLine.Substring(0, 7);
                newRow["per_pid"] = theLine.Substring(7, 7);
                newRow["per_name"] = theLine.Substring(14, 20);
                newRecs.Rows.Add(newRow);
            }
        }
        SqlBulkCopy bulkCopy = new SqlBulkCopy(connection);
        bulkCopy.WriteToServer(newRecs);
    }
