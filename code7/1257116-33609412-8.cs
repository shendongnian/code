    class Test
    {
        public string SendData(string val1){ return val1; }
        public void RecoverBirth(out string result)
        {
            clsConnectionClass conn = new clsConnectionClass();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            cmd.CommandText = "select * from birthday";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    result += SendData(dr[1].ToString() + " " + dr[2].ToString() + "\r\n");
                }
            }
        }
    }
