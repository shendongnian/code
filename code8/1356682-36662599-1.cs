    param[1] = new SqlParameter("@FromDate", SqlDbType.DateTime);
    param[1].Value = FromDate;
    param[1].Value = DBNull.Value;
    
    param[2] = new SqlParameter("@ToDate", SqlDbType.DateTime);
    param[2].Value = ToDate;
    param[2].Value = DBNull.Value;
