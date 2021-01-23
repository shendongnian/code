    BindingSource b = new BindingSource();
    
    string cus1 = getCustomers.getCustomersApi();
    RootObject cus = JsonConvert.DeserializeObject<RootObject>(cus1);
    
    dataGridView2.Columns.Clear();
    AddCheckBoxForDataGridViewCustomer();
    var result = cus.Rows.Select(r => new
        CustomerGridModel
        {
            CustomerId = r.CustomerId,
            Name = r.Name,
            Code = r.Code,
            Address = r.Address,
            PostalCode = r.PostalCode,
            City = r.City,
            Country = r.Country.Name,
            TaxNumber = r.TaxNumber,
        }).ToList();
    
    b.DataSource = result;
    dataGridView2.DataSource = b;
    dataGridView2.ReadOnly = false;
