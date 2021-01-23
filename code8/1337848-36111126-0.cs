    OleDbDataAdapter da = new OleDbDataAdapter("select * from input_alignments", cn);
    DataSet ds = new DataSet();
    da.Fill(ds);
    DataTable table = ds.Tables[0];         // use integer index instead of string one
    foreach (DataRow row in table.Rows)
    {
        sb.Append(row["word1"].ToString();
    }
