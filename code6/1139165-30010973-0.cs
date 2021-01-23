    //Plural as it is a list
    List<SalesInvoice> salesInvoices = new List<SalesInvoice>();
            
    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
    {
        //Singular as it is a single element
        var salesInvoice = new SalesInvoice();
        salesInvoice.DocNo = dataGridView1.Rows[i].Cells[0].FormattedValue.ToString();
        salesInvoice.Item = dataGridView1.Rows[i].Cells[1].FormattedValue.ToString();
        salesInvoice.Qty = dataGridView1.Rows[i].Cells[2].FormattedValue.ToString();
        salesInvoice.Price = dataGridView1.Rows[i].Cells[3].FormattedValue.ToString();
        salesInvoices.Add(salesInvoice);
                
        //What's the purpose of the next line?
        var serializer1 = new XmlSerializer(typeof(SalesInvoice));
    }
    // I pluralized this property name too
    data.SalesInvoices = salesInvoices.ToArray();
