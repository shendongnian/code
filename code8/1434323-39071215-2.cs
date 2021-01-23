private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime getdate = DateTime.Now;
            String time = getdate.ToString("F");
            try
            {
                
                var rows = new[]
                {
                    new {Item = txtItem.Text, Product = txtProduct.Text, Quantity = txtQuantity.Text},
                    new {Item = txtItem2.Text, Product = txtProduct2.Text, Quantity = txtQuantity2.Text},
                    new {Item = txtItem3.Text, Product = txtProduct3.Text, Quantity = txtQuantity3.Text},
                    new {Item = txtItem4.Text, Product = txtProduct4.Text, Quantity = txtQuantity4.Text},
                    new {Item = txtItem5.Text, Product = txtProduct5.Text, Quantity = txtQuantity5.Text},
                    new {Item = txtItem6.Text, Product = txtProduct6.Text, Quantity = txtQuantity6.Text},
                    new {Item = txtItem7.Text, Product = txtProduct7.Text, Quantity = txtQuantity7.Text},
                    new {Item = txtItem8.Text, Product = txtProduct8.Text, Quantity = txtQuantity8.Text},
                    new {Item = txtItem9.Text, Product = txtProduct9.Text, Quantity = txtQuantity9.Text},
                    new {Item = txtItem10.Text, Product = txtProduct10.Text, Quantity = txtQuantity10.Text}
                };
                foreach (var row in rows)//Check if ItemCode exist
                {
                    con.Open();
                    if (!String.IsNullOrEmpty(row.Item))
                    {
                        OleDbCommand command = new OleDbCommand(@"Select * from TblInventory where ItemCode='" + txtItem.Text + "'");
                        command.Connection = con;
                        command.Parameters.AddWithValue("itemcode", txtItem.Text);
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
                    else //Add new Data if Item Code is not exit;
                    {
                        var rows2 = new[]
                        {
                             new {Item = txtItem.Text, Product = txtProduct.Text, Quantity = txtQuantity.Text},
                             new {Item = txtItem2.Text, Product = txtProduct2.Text, Quantity = txtQuantity2.Text},
                             new {Item = txtItem3.Text, Product = txtProduct3.Text, Quantity = txtQuantity3.Text},
                             new {Item = txtItem4.Text, Product = txtProduct4.Text, Quantity = txtQuantity4.Text},
                             new {Item = txtItem5.Text, Product = txtProduct5.Text, Quantity = txtQuantity5.Text},
                             new {Item = txtItem6.Text, Product = txtProduct6.Text, Quantity = txtQuantity6.Text},
                             new {Item = txtItem7.Text, Product = txtProduct7.Text, Quantity = txtQuantity7.Text},
                             new {Item = txtItem8.Text, Product = txtProduct8.Text, Quantity = txtQuantity8.Text},
                             new {Item = txtItem9.Text, Product = txtProduct9.Text, Quantity = txtQuantity9.Text},
                             new {Item = txtItem10.Text, Product = txtProduct10.Text, Quantity = txtQuantity10.Text}
                        };
                        foreach (var row2 in rows)
                        {
                            if (!String.IsNullOrEmpty(row2.Item) && !String.IsNullOrEmpty(row2.Product) && !String.IsNullOrEmpty(row2.Quantity))
                            {
                                OleDbCommand cmdInsert = new OleDbCommand(
                                                 @"insert into TblInventory (ItemCode,ProductName,Quantity,DateAndTime)values(@ItemCode,@ProductName,@Quantity,@DateAndTime)");
                                cmdInsert.Connection = con;
                                cmdInsert.Parameters.AddWithValue("ItemCode", row2.Item);
                                cmdInsert.Parameters.AddWithValue("ProductName", row2.Product);
                                cmdInsert.Parameters.AddWithValue("Quantity", row2.Quantity.ToString());
                                cmdInsert.Parameters.AddWithValue("DateAndTime", DateTime.Now);
                                cmdInsert.ExecuteNonQuery(); HERE
                                MessageBox.Show("You added " + row.Quantity + " " + row.Product, "New Item");
                            }
                        }
                    }
                    showGrid2();
                    clear();
                    con.Close();
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
