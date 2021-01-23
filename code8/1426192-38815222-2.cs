     private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
     {
       //addtoorders
      if (listStocks.SelectedIndex >= 0)
      {
          DataRowView row = (DataRowView)listStocks.SelectedItems[0];
          Orders o=(Orders)row;
          List<Orders> orderlist=( List<Orders>)listOrders.ItemsSource;
          if(orderlist.Find(x=>x.PRoductID==c1.PRoductID)!=null)
            {
               MessageBox.Show("This Product already exists!");
            }
          else
           {
              listOrders.Items.Add(orders);
           }   
          
      }
   }
 
