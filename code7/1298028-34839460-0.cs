            command.CommandText = q;
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            { while (reader.Read())
                {
                    listBox1.Items.Add(reader["Behandeling"].ToString());
                }
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception a)
        {
            connection.Close();
            MessageBox.Show(a.Message.ToString());
        }
