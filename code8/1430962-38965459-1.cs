    using(MySqlConnection mcon = new MySqlConnection(constr))
    {
        using(MySqlCommand command = mcon.CreateCommand())
        {
          command.CommandText = " update pointofcontact set Password = ?pwd," +
                                " FirstName = ?firstname," +
                                " LastName = ?lastname," +
                                " ContactNumber = ?contact," +
                                " EmailAddress = ?email," +
                                " Address = ?address," +
                                " BackupContactNumber = ?backupnumber" +
                                " where Username = ?Username";
          mcon.Open();
          if (tbNewPassword.Text == null)
          {
              command.Parameters.AddWithValue("?pwd", tbOldPassword.Text.Trim());
          }
          else
          {
              command.Parameters.AddWithValue("?pwd", tbNewPassword.Text.Trim());
          }
          command.Parameters.AddWithValue("?firstname", tbFirstName.Text.Trim());
          command.Parameters.AddWithValue("?lastname", tbLastName.Text.Trim());
          command.Parameters.AddWithValue("?contact", tbMobile.Text.Trim());
          command.Parameters.AddWithValue("?email", tbEmail.Text.Trim());
          command.Parameters.AddWithValue("?address", tbAddress.Text.Trim());
          command.Parameters.AddWithValue("?backupnumber", tbBackupContact.Text.Trim());
          command.Parameters.AddWithValue("?Username", username.ToString());
        
          command.ExecuteNonQuery();
        }
    }
