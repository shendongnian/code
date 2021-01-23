        OracleConnection obj_Conn = new `OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["oracleConn"].ToString());`
        Table table = new Table();
        table.ID = "table1";
        string Querry = "SELECT * FROM XXCUS.MASTER_VERIFICATION";
        OracleDataAdapter da = new OracleDataAdapter(Querry, obj_Conn);
        //DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(dt);
        var Count = dt.Rows.Count;
        if (Count > 0)
        {
            TableRow row = new TableRow();
            TextBox txt = new TextBox();
            for (int i = 0; i < Count; i++)
            {
    TextBox txt = new TextBox();            
    TableCell cell = new TableCell();
                txt.ID = "txt" + i.ToString();
                cell.ID = "cell" + i.ToString();
    
                cell.Controls.Add(txt);
    
                row.Cells.Add(cell);
            }
            table.Rows.Add(row);
            dvGenerateCntrl.Controls.Add(table);
        }
