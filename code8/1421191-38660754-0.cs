        InsertWarning.Parameters.Add("@idUser", SqlDbType.Int);
        InsertWarning.Parameters["@idUser"].Value = userIDAuth;
        InsertWarning.Parameters.AddWithValue("@idPass", idPass);
       try
       {
            connection.Open();
            InsertWarning.ExecuteNonQuery()
       }
      catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
     
