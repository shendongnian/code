    using (var writer = conn.BeginBinaryImport(
        "copy user_data.part_list from STDIN (FORMAT BINARY)"))
    {
        foreach (var record in RecordList)
        {
            writer.StartRow();
            writer.Write(record.UserId);
            writer.Write(record.Age, NpgsqlTypes.NpgsqlDbType.Integer);
            writer.Write(record.HireDate, NpgsqlTypes.NpgsqlDbType.Date);
        }
        writer.Complete();
    }
