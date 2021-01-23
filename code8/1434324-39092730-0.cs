    foreach (var row in rows)//Check if ItemCode exist
                        {
                               
                                if (!String.IsNullOrEmpty(row.Item))
                                {
                                    OleDbCommand command = new OleDbCommand(@"Select * from TblInventory where ItemCode='" + txtItem.Text + "'");
                                    using (command.Connection = con)
    								{
                                    command.Parameters.AddWithValue("itemcode", txtItem.Text);
    								con.open;
                                    OleDbDataReader reader = command.ExecuteReader();
            
                                    if (reader.Read())
                                    {
                                        OleDbCommand cmd = new OleDbCommand(@"Update TblInventory set Quantity = Quantity + @Quantity WHERE ItemCode = @itemcode");
            
                                        cmd.Connection = con;
                                        cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text));
                                        txtProduct.Text = reader["ProductName"].ToString();
                                        cmd.Parameters.AddWithValue("@itemcode", txtItem.Text);
                                        cmd.Parameters.AddWithValue("@DateAndTime", time);
                                        cmd.ExecuteNonQuery();// HERE
                                        MessageBox.Show("You added " + txtQuantity.Text + " " + txtProduct.Text, "Existing Item");
    								}
    							   }
    							   
    					}
    			}
    	//dont use con.Close anywhere in the code .	   
    							   
    							   
    							   
							   
