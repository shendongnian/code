    public bool ChangePassword(string code, string pwd)
    {
        using(DbConnection conn = GetConnection())
        {
            string sql = "UPDATE Staff WHERE pwd=@pwd AND code=@code";
            int updatedRowsCount = conn.Query<int>(sql, new { code, pwd }).First();
            return updatedRowsCount == 1;
        }
    }
