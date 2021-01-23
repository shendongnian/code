    // Add each of your new entities to their appropriate table in the context and then save
    // your changes
    entities.Invoices.Add(new Invoice(){
        Customer_name = viewModel.Customer_name,
        Customer_Address = viewModel.Customer_Address
    });
    entities.LineItems.Add(new LineItem(){
        Quantity = viewModel.Quantity,
        Total = viewModel.Total
    });
    entities.Producs.Add(new Produc(){
        Product_name = viewModel.Product_name,
        Unit_Price = viewModel.Unit_Price
    });
    // Now save your changes
    entities.SaveChanges();
