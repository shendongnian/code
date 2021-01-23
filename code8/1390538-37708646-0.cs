       SqlCeCommand cmd = new SqlCeCommand("select MyInt32Column, MyVarCharColumn, MyBitColumn from MyTable;", con);
        SqlCeDataReader reader;
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int myInt32Value = reader.GetInt32(0);
                string myStringValue = reader.GetString(1);
                bool myBooleanValue = reader.GetBoolean(2);
            }
