      DataTable Orders = Orders.Tables[Lines];
    CurrentLine.DataSource = Orders;
    
          for (int i = 0; i < CurrentLine.Rows.Count-1; i++)
                  {
                      string product =Orders.Rows[i][1].ToString (); //This loop sets the values of the combobox according to the order lines in the orderline table in the dataset.
                      CurrentLine.Rows[i].Cells[4].Value = product;
                  }
    
                  DataColumn LinePrice = new DataColumn("Line Price");
                  Orders.Columns.Add(LinePrice);
