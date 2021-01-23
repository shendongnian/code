    public Int64 SelectLetterNoFromComposedLetter() 
            {
                SqlCommand cmd = new SqlCommand("SelectLetterNoFromComposedLetter", DataBaseConnection.OpenConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pLetterNo = new SqlParameter("@LetterNo", SqlDbType.BigInt);
                cmd.Parameters.Add(pLetterNo);
                pLetterNo.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                Int64 Result = Convert.ToInt64(cmd.Parameters["@LetterNo"].Value);
                return Result;
            }
