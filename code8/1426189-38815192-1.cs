    private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
    {
        //addtoorders
        if (listStocks.SelectedIndex >= 0)
        {
        DataRowView row = (DataRowView)listStocks.SelectedItems[0];
        var found = ordersobject.FirstOrDefault(x=>x.Contains(row["productID"].ToString()));
            
            if(found == null)
            {
                //According to my knowledge a new object i.e., 
                //List<Orders> orders = new List<Orders>(); doesn't have to be defined below 
                //provided that you have defined an object of class Orders before, 
                //unless you want to create various objects of Orders. 
                //Which will cause a lot of trouble in future.
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
        }
     }
