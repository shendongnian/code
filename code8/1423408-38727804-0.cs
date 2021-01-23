    private void dataGridCustomers_SelectionChanged(object sender, SelectionChangedEventArgs args)
    {
        if (args.AddedItems.Length > 0)
        {
            Customer selectedCustomer = (Customer) args.AddedItems[0];
            MessageBox.Show(selectedCustomer.FirstName);
        }
    }
