	List<MyItemClass> items = new List<MyInvoiceClass>();
	items.Add(new MyInvoiceClass() { InvoiceNo = "10", ProductID = 42, .... });
	items.Add(new MyInvoiceClass() { InvoiceNo = "11", ProductID = 39, .... });
	items.Add(new MyInvoiceClass() { InvoiceNo = "12", ProductID = 7, .... });
    //Assign list of objects (Invoice List) to ItemsSource property
	ListView1.ItemsSource = items;
