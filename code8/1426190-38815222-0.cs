     private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
     {
       //addtoorders
      if (listStocks.SelectedIndex >= 0)
      {
          DataRowView row = (DataRowView)listStocks.SelectedItems[0];
          List<Orders> orders = new List<Orders>();
          orders.Add(new Orders()
        {
            ProductID = row["productID"].ToString(),
            ProductName = row["productName"].ToString(),
            Price = Convert.ToDouble(row["sellingPrice"]),
            Quantity = Convert.ToInt32(row["quantity"])
        });
      if(listOrders.Items.Contains(textBox1.Text)) 
      {
        MessageBox.Show("This Product already exists!");
      }
      else
      {
        listOrders.Items.Add(orders);
      }   
       
      }
   }
 
