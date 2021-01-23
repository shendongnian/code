    using(var sqlcon = new SqlConnection(conString))
    using(var sqlcmd = sqlcon.CreateCommand())
    {
       sqlcmd.CommandText = "INSERT INTO TBL_NUMUNEKAYITDEFTERI(NUMUNEADI, NUMUNEGONDEREN) VALUES(@ad, @gonderen)";
       sqlcmd.Parameters.Add("@ad", SqlDbType.NVarChar).Value = cmbxNumuneCinsi.Text;
       sqlcmd.Parameters.Add("@gonderen", SqlDbType.NVarChar).Value = cmbxGonderen.Text;
        
       sqlcon.Open();
       sqlcmd.ExecuteNonQuery();
    }
