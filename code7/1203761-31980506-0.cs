    public class FactureInfo
    {
        public int Facture {get; set;}
        public int Nbre {get; set;}
    }
    public IList<FactureInfo> GetFactureInfo()
    {
        DbConnection conn = null;
        DbDataReader reader = null;
        
        try
        {
            conn = new OleDbConnection(
                "Provider=Microsoft.Jet.OLEDB.4.0; " + 
                "Data Source=" + Server.MapPath("MyDataFolder/MyAccessDb.mdb"));
            conn.Open();
            DbCommand cmd = 
                new OleDbCommand("select facture, count(l.le_ville) as nbre
                    from table
                    group by l.le_ville", conn);
            reader = cmd.ExecuteReader();
            var factures = new List<FactureInfo>();
            while(reader.Read())
            {
                var factureInfo= new FactureInfo();
                factureInfo.Facture = reader.GetInt32(reader.GetOrdinal("facture"));
                factureInfo.Nbre = reader.GetInt32(reader.GetOrdinal("nbre"));
                factures.Add(factureInfo);
            }
            return factures;
        }
        finally
        {
            if (reader != null)  reader.Close();
            if (conn != null)  conn.Close();
        }
        return null;
    }
