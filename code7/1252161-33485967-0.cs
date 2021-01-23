    public void AssociateCorpToProj(int pd, int cd) 
    {
        using(SqlConnection cn = new SqlConnection(_dbConnection)) 
        {
            using(SqlCommand cm = new SqlCommand("InsertProjectEntity", cn)) 
            {
                cm.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cm.Parameters.AddWithValue("@ProjectID", pd);
                cm.Parameters.AddWithValue("@CorpID", cd);
                cm.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
