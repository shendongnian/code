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
               cmdInsert.ExecuteNonQuery();
               MessageBox.Show("You added " + row.Quantity + " " + row.Product, "New Item");
                        }
                    }
                }
                showGrid2();
                clear();
            }
            con.Close();
        }
