    LocalReport.SubreportProcessing += Customers_SubreportProcessing;
    private void Customers_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        ReportParameterInfo customerId = e.Parameters.FirstOrDefault(c => c.Name == "CustomerId");
        if (customerId== null)
            return;
        Customer customer = _customersList
            .FirstOrDefault(c => c.CustomerId == customerId.Values.FirstOrDefault());
        if (e.ReportPath == "CustomersOrders") // Name for subreport CustomersOrders.rdlc
        {
            e.DataSources.Add(new ReportDataSource("Orders", customer.Orders));
        }
        else if (e.ReportPath == "CustomersComments") // Name for subreport CustomersComments.rdlc
        {
            e.DataSources.Add(new ReportDataSource("Comments", customer.Comments));
        }
    }
