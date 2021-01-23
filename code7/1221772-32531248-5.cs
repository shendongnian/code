    private void tbSelection_LostFocus(object sender, RoutedEventArgs e)
    {
                
        if (string.IsNullOrWhiteSpace(tbSelection.Text) == false)
        {
            int userOrderId; 
    
            if (int.TryParse(tbSelection.Text, out userOrderId))
            {
                var orders = myGrid.ItemsSource as List<Order>;
    
                var order = orders.FirstOrDefault(ord => ord.OrderId == userOrderId);
    
                if (order != null)
                    myGrid.SelectedItem = order;
                else
                    myGrid.SelectedIndex = -1; // Default to nothing.
    
            }
            else
                myGrid.SelectedIndex = -1; // Default to nothing.
        }
    
    }
    
