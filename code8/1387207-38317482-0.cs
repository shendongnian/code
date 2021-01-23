    //elsewhere
    public class GetAllProgress
    {
        public GetAllProgress(int count, int total)
        {
            Count = count;
            Total = total;
        }
        
        public Count {get;}
        public Total {get;}
    }
    public List<VatRate> GetAll( string cnString, IProgress<GetAllProgress> progress )
    {
        List<VatRate> result = new List<VatRate>();
        using (SqlConnection cn = new SqlConnection(cnString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = SQL_SELECT_COUNT;
            cmd.CommandType = System.Data.CommandType.Text;
            cn.Open();
            var totalCount = (int)cmd.ExecuteScalar();
            progress.Report(new GetAllProgress(0, totalCount));
            cmd.CommandText = SQL_SELECT; 
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                //reader.HasRows is unnecessary, if there are no rows reader.Read() will be false the first call
                while (reader.Read())
                {
                    VatRate vr = new VatRate();
                    vr.IDVatRate = reader["IDVatRate"] == System.DBNull.Value ? Guid.Empty : (Guid)reader["IDVatRate"];
                    vr.Percent = reader["Percent"].XxNullDecimal();
                    vr.Type = reader["Type"].XxNullString();
                    vr.VatRateDescription = reader["VatRateDescription"].XxNullString();
                    result.Add(vr);
                    progress.Report(new GetAllProgress(result.Count, TotalCount));
                }
                //I put reader in a using so you don't need to close it.
            }
            //You don't need to do cn.Close() inside a using
        }
        return result;
    }
