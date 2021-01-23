        NpgsqlConnection conn = new NpgsqlConnection();
        conn.Open();
        Excel.Application xl = new Excel.Application();
        xl.Visible = true;
        Excel.Workbook wb = xl.Workbooks.Add(1);
        Excel.Worksheet ws = (Excel.Worksheet)wb.Sheets[1];
        List<string> parts = new List<string>();
        NpgsqlCommand cmd = new NpgsqlCommand("select prod_id from mdm.global_item_master",
            conn);
        NpgsqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
            parts.Add(reader.GetString(0));
        reader.Close();
        NpgsqlCopyIn copy = new NpgsqlCopyIn(
            "copy mdm.excel_item_id from STDIN WITH NULL AS '' CSV;", conn);
        copy.Start();
        NpgsqlCopySerializer cs = new NpgsqlCopySerializer(conn);
        cs.Delimiter = ",";
        foreach (string part in parts)
        {
            ws.Cells[1, 1].Value2 = part;
            cs.AddString(part);
            cs.AddString(ws.Cells[1, 1].Text);
            cs.EndRow();
        }
        cs.Close();
        copy.End();
        conn.Close();
