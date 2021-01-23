    foreach (DataRow dr in dt.Rows)
    {
        str = "";
        for (int j = 0; j < dt.Columns.Count; j++)
        {
            Response.Write(str + Convert.ToString(dr[j]));
            str = "\t";
        }
        Response.Write("\n");
        if (unchecked(++rowCount % 1024 == 0))
            Response.Flush();
    }
