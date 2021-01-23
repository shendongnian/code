    if (ValidateHeaders(importData, importDataSourceSchema))
    {
        using (SqlBulkCopy bulkCopy = new SqlBulkCopy([Add your ConnectionString here]))
        {
            bulkCopy.DestinationTableName = "dbo.EmployeeImport";
            bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("FirstName", "FirstName"));
            bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("LastName", "LastName"));
            bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Hire Date", "HireDate"));
            try
            {
                bulkCopy.WriteToServer(importData);
                ValidationLabel.Text = "Success";
                GridView1.DataSource = importData;
                GridView1.DataBind();
            }
            catch (Exception e)
            {
                ValidationLabel.Text = e.Message;
            }
        }
    }
