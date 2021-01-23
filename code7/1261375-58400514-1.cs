    public DataTable GET_SAMPLE_KIND(int TESTID)
            {
                DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
                DataTable dt = new DataTable();
    
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@TESTID", SqlDbType.Int);
                param[0].Value = TESTID;
    
                dt = DAL.SelectData("GET_SAMPLE_KIND", param);
                DAL.close();
                return dt;
            }
