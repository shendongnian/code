    private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            bool found = ProductFound.Found(/*In Method Enter The Code For Found*/);
            //addtoorders
            if (!found)
            {
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
                    listOrders.Items.Add(orders);
                }
            }else{
              //If Not Found What's Doing
            }
        }
