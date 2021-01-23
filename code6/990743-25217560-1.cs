    public bool ChangePassword(string code, string pwd)
    {
        using(DbConnection conn = GetConnection())
        {
            string sql = "UPDATE Staff SET pwd=@pwd WHERE code=@code";
            int updatedRowsCount = conn.Query<int>(sql, new { code, pwd }).First();
            return updatedRowsCount == 1;
        }
    }
