        public static void MyHigherLevelFunction(Transaction aTran, long Id, byte[][] data)
        {
            foreach(byte[] oneData in data)
            {
                MyFunction(aTran, Id, oneData);
            }
        }
        public static void MyFunction(Transaction aTran, long Id, byte[] data)
        {
            string cmdText = ExtendedSQL.SQLQuery;
            using (SqlCommand cmd = new SqlCommand(cmdText))
            {
                cmd.Parameters.Add("@data", SqlDbType.VarBinary, data.Length).Value = data
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
