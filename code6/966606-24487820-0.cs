    public static void DataTableToCsv(DataTable dt, string filename, CsvOptions options, string headerLine)
    {
        using (StreamWriter writer = new StreamWriter(filename, false, options.Encoding, 102400))
        {
            // output header
            writer.Write(headerLine);
            writer.Write(StringHelper.NewLine);
            foreach (DataRow row in dt.Rows)
            {
                object[] itemArray = row.ItemArray;
                for (int i = 0; i < itemArray.Length; i++)
                {
                    if (i > 0)
                    {
                        writer.Write(options.Delimiter);
                    }
                    writer.Write(options.ValueToString(itemArray[i]));
                }
                writer.Write(StringHelper.NewLine);
            }
            writer.Close();
        }
    }
