                string email = p_Email.Text;
                string password  = tb_Confirm.Text
                try
                    {
                            connect.Open();
                            OleDbCommand cmd = connect.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "UPDATE userInformation SET [password]= @password WHERE emailAddress= @email";
                            cmd.Parameters.AddWithValue("@password", tb_Confirm.Text);
                            cmd.Parameters.AddWithValue("@email", p_Email.Text);
                           
                            cmd.ExecuteNonQuery();
                            
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connect.Close();
                    }
