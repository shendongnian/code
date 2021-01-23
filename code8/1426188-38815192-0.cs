    if (listStocks.SelectedIndex >= 0)
    {
        //Define a bool as false i.e bool found = false
        //Search for the Product ID if ProductID exists then make found = true
        if(!found) //If product ID doesn't exist then the code below is executed
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
            listOrders.Items.Add(orders);
         }
     }
