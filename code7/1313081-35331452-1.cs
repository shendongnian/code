        try
        {
            using (var sc = new SqlConnection(dbConnString))
            using (var cmd = sc.CreateCommand())
            {
                sc.Open();
                var nosConcat = "1,2,3,4,5";
                string failedIds = string.Empty;
                var ids = nosConcat.Split(',');
                string @delTblName = "sometable";
                string @delColumnName = "somecolumn";
                for(int i = 0 ; i < ids.Length ; i++)
                {
                    try
                    {
                        cmd.CommandText = "DELETE FROM " + @delTblName + " WHERE " + @delColumnName + " = @valConcat ";
                        cmd.Parameters.AddWithValue("@valConcat", ids[i]);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Errors[0].Number == 444) //Use the actual error number that you get on foreign key confilict
                            failedIds += "," + ids[i];
                    }
                }
            }
        }
        catch
        {
        }
