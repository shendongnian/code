    InvoiceNumbertxt.Text = sr.ReadLine();
    InvoiceDatetxt.Text = sr.ReadLine();
    ...
    Items.Add(new ItemProperties 
                            {     
                                Item = sr.ReadLine();
                                Description = sr.ReadLine();
                            });
