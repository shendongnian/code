        public int Create(string query)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int returnVal = cmd.ExecuteNonQuery();
            conn.Close();
            return returnVal;
        }
