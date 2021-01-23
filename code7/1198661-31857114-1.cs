    string sSql = "Create Table [Sheet1$] (Col1 Int, Col2 Int, Col3 Int, NewColumn Int)";
    using (OleDbCommand oCmd = new OleDbCommand(sSql, oConnection))
    {
        oCmd.ExecuteNonQuery();
    }
