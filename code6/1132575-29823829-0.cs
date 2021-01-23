                   SqlCommand com = new SqlCommand();
                    com.Connection = new SqlConnection(Properties.Settings.Default.BioEngineering);
                    com.Connection.Open();
                    com.CommandText = "INSERT INTO AccessHistory (DoorID,UserID,TimeAccess,Status) VALUES (@DoorID,@UserID,getdate(),@Status)";
                    com.Parameters.Add("@DoorID", SqlDbType.Int).Value = DoorNumber;
                    com.Parameters.Add("@UserID", SqlDbType.Int).Value = cboUserID.Text;
                   com.Parameters.Add("@Status", SqlDbType.VarChar).Value = "Successful";
