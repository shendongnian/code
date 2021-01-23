    public bool UsernameExistInDatabase(string username)
    {
        using (SqlConnection con = new SqlConnection(this._connectionString))
        {
            string query = "SELECT COUNT(username) FROM tbl_sample WHERE (lock = 1)";
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result > 0)
                {
                    // No worries about con.Close()! Using will handle it
                    return true;
                }
            }
        }
        return false;
    }
