            using (SqlCommand SelectCommand = new SqlCommand(strbSelect.ToString()))
            {
                    SelectCommand.Parameters.AddWithValue("Asset", AssetNumber);
                    SelectCommand.Parameters.AddWithValue("Subnumber", Subnumber);
                    SelectCommand.Connection = new SqlConnection(GetConnectionString());
                    SelectCommand.Connection.Open();
                    using (SqlDataReader Reader = SelectCommand.ExecuteReader())
                    {
                        if (Reader.HasRows)
                        {
                            while (Reader.Read())
                            {
                                if (Reader[0] != DBNull.Value)
                                {
                                    ReturnValue = Reader.GetBoolean(0);
                                }
                            }
                        }
                        else
                            return false;
                    }
                    SelectCommand.Connection.Close();
            }
