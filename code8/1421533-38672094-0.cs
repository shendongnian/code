      public static bool SomeMethod(int valueId)
        {
            bool result;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataConnection.MailForm))
                {
                    connection.Open();
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"SELECT COUNT(*) FROM Mails
                                                   WHERE ValueID= @valueId";
                        cmd.Parameters.AddWithValue("@valueId", valueId);
                        int entryIdExist = Convert.ToInt32(cmd.ExecuteScalar());
                        result = entryIdExist <= 0;
                    }
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
