     try
            {
                using (var connection1 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=mydb.mdb"))
                {
                    connection1.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    
                    Int32 count = 0; // (Int32)cmd.ExecuteScalar();
                    string Query = "select count(*) from Stand where Number='" + comboBox1.Text + "'";
                    using (cmd = new OleDbCommand(Query, connection1))
                    {
                        cmd.CommandType = CommandType.Text;
                        count = (Int32)cmd.ExecuteScalar();
                    }
                    if (count == 1)
                    {
                        label1.Text = comboBox1.Text + " is Already Exist!";
                    }
                    else
                    {
                        using (cmd = new OleDbCommand("insert into Stand ([Number]) values (@Value)", connection1))
                        {
                            //cmd.Connection = connection1;
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Value", 3);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            } 
