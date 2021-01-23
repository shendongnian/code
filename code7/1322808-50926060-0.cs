    public async Task<List<Ranks>> GetRanks(string value1, Nullable<decimal> value2)
    {
        SqlParameter value1Input = new SqlParameter("@Param1", value1?? (object)DBNull.Value);
        SqlParameter value2Input = new SqlParameter("@Param2", value2?? (object)DBNull.Value);
        List<Ranks> getRanks = await this.Query<Ranks>().FromSql("STORED_PROCEDURE @Param1, @Param2", value1Input, value2Input).ToListAsync();
        return getRanks;
    }
