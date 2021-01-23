        NpgsqlCopyIn copy = new NpgsqlCopyIn("copy table1 from STDIN WITH NULL AS '' CSV;",
            conn);
        copy.Start();
        NpgsqlCopySerializer cs = new NpgsqlCopySerializer(conn);
        cs.Delimiter = ",";
        foreach (var record in RecordList)
        {
            cs.AddString(record.UserId);
            cs.AddInt32(record.Age);
            cs.AddDateTime(record.HireDate);
            cs.EndRow();
        }
        cs.Close();
        copy.End();
