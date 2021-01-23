    using(var connection = new SqlConnection("Your Connection String"))
    {
          var query = "INSERT INTO tblVoice(flbVoice) VALUE (@file)";
          using(var command = new SqlCommand(query, connection))
          {
               connection.Open();
               // Pass your byte data as a parameter
               command.Parameters.AddWithValue("@file",byteArrayFile);
               // Execute your parameter
               command.ExecuteNonQuery();
          }
    }
