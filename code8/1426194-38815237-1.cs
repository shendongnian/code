    private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            
            //addtoorders
            if (listStocks.SelectedIndex >= 0)
            {
                DataRowView row = (DataRowView)listStocks.SelectedItems[0];
                Orders newOrder = new Orders()
                {
                    ProductID = row["productID"].ToString(),
                    ProductName = row["productName"].ToString(),
                    Price = Convert.ToDouble(row["sellingPrice"]),
                    Quantity = Convert.ToInt32(row["quantity"])
                };
                List<Orders> orders = new List<Orders>();
                //
                bool found = false;
                foreach(Orders order in orders)
                {
                    if (order.Equals(newOrder))
                    {
                        //if Found Order Equal NewOrder
                        found = true;
                        break;
                    }
                }
                if(found == true)
                {
                    Console.WriteLine("We are Found Order = NewOrder");
                    return; //Exit From Method
                }
                //If Found == false
                orders.Add(newOrder);
                listOrders.Items.Add(orders);
            }
        }
