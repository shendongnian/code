    using (rptCustomer rpt = new rptCustomer())
    {
        var dataSet = new DataSet("TestDataSet");
        var table = CreateTestData();
        dataSet.Tables.Add(table);
        rpt.DataSource = dataSet;
        rpt.DataMember = table.TableName;
        rpt.xrLabel.Text = "[CustomerID] - [CustomerName]"; // Suddenly, it's work.
        //rpt.xrLabel.DataBindings.Add("Text", null, "Customer.CustomerID"); -- It's work too.
        rpt.xrCustomerID.DataBindings.Add("Text", null, "Customer.CustomerID");
        rpt.xrCustomerName.DataBindings.Add("Text", null, "Customer.CustomerName");
        rpt.xrCustomerAddress.DataBindings.Add("Text", null, "Customer.Address");
        rpt.ShowPreviewDialog();
    }
