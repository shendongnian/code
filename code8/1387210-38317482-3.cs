    public async Task<List<VatRate>> GetAllAsync( string cnString, IProgress<GetAllProgress> progress )
    {
        List<VatRate> result = new List<VatRate>();
        using (SqlConnection cn = new SqlConnection(cnString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = SQL_SELECT_COUNT;
            //The .ConfigureAwait(false) makes it so it does not need to wait for the UI thread to become available to continue with the code.
            await cn.OpenAsync().ConfigureAwait(false);
            var totalCount = (int)await cmd.ExecuteScalarAsync().ConfigureAwait(false);
            progress.Report(new GetAllProgress(0, totalCount));
            cmd.CommandText = SQL_SELECT; 
            using(SqlDataReader reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
            {
                while (await reader.ReadAsync().ConfigureAwait(false))
                {
                    VatRate vr = new VatRate();
                    vr.IDVatRate = reader["IDVatRate"] == System.DBNull.Value ? Guid.Empty : (Guid)reader["IDVatRate"];
                    vr.Percent = reader["Percent"].XxNullDecimal();
                    vr.Type = reader["Type"].XxNullString();
                    vr.VatRateDescription = reader["VatRateDescription"].XxNullString();
                    result.Add(vr);
                    progress.Report(new GetAllProgress(result.Count, TotalCount));
                }
            }
        }
        return result;
    }
