    private string GetMessaggio(string eventNumber)
    {
        using (var adapt = new OleDbDataAdapter())
        using (var dt = new DataTable())
        {
            var stm = new ADODB.Stream();
            var rsCopy = new ADODB.Recordset();
            var rs = ((ADODB.Recordset)Dts.Variables["User::RS_EventType"].Value).Clone();
    
            rs.Save(stm);
            rsCopy.Open(stm);
    
            adapt.Fill(dt, rsCopy);
    
            rs.Close();
            stm.Close();
            rsCopy.Close();
            Marshal.ReleaseComObject(stm);
            Marshal.ReleaseComObject(rsCopy);
            Marshal.ReleaseComObject(rs);
    
            return dt.AsEnumerable()
                        .Where(r => r.Field<int>("ev_number").ToString() == eventNumber)
                        .Select(r => r.Field<string>("ev_message"))
                        .FirstOrDefault() ?? "ND";
        }
    }
