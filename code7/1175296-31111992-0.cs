    string jointS = dsetChamberS1.Tables[0].Rows[tot][0].ToString();
    int select1S = Convert.ToInt32(jointS);
    using(var conn = new OleDbConnection(conString))
    using(var cmd1S = conn.CreateCommand())
    {
        cmd1S.CommandText = "SELECT TMin,TMax,HMin,HMax from ScannerAlarmLimits WHERE ScannerID = @id";
        cmd1S.Parameters.AddWithValue("@id", OleDbType.Integer).Value = select1S;
    
        using(var adapter1S = new OleDbDataAdapter(cmd1S))
        {
            adapter1S.Fill(dsetTempS, "ScannerAlarmLimits");
        }
    }
