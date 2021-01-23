    SqlCommand cmd = ...;
    using (SqlDataReader reader = cmd.ExecuteReader())
    using (StreamWriter writer = new StreamWriter(outputPath))
    {
        while (reader.Read())
        {
            writer.Write("\"");
            for (int v = 0; v < reader.FieldCount; v++)
            {
                if (v > 0)
                    writer.Write("\",\"");
                writer.Write(reader[v]);
            }
            writer.Write("\"");
            writer.WriteLine();
        }
    }
