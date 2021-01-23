     private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
     {
       //addtoorders
      if (listStocks.SelectedIndex >= 0)
      {
          DataRowView row = (DataRowView)listStocks.SelectedItems[0];
          Orders o=(Orders)row;
          if(listOrders.Items.Contains(o))
            {
               MessageBox.Show("This Product already exists!");
            }
          else
           {
              listOrders.Items.Add(orders);
           }   
          
      }
   }
 
