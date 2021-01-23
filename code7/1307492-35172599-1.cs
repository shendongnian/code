    private void btnFeedbackAddSupplier_Click(object sender, RoutedEventArgs e) 
    {
        // ...        
        columnSupplier.Binding = new Binding(string.Format("Supplier[{0}]", supplierColumnIndex));
        // ...
        var supplierCosts = new List<int>();
        // ...
        // Fill the list with the Costs of the Suppliers that correspond to each column and item
        // ...
        var collection = (from i in items let a = new ViewQuoteItemList { Item = i.Item, Supplier = supplierCosts }
                              select a).ToList();
    
        //Adds both the column and data to the 2nd datagrid
        dgFeedbackSelectSupplier.Columns.Add(columnSupplier);
        foreach (var item in collection)
            dgFeedbackSelectSupplier.Items.Add(item); 
    }
