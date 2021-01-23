    try
    {
        var dataTable = new DataTable();
        
        dataTable.Columns.Add("DocumentType");
        dataTable.Columns.Add("DocumentName");
        foreach (CSDoc Myelement in Documents)
        {
            var newRow = dataTable.NewRow();
            // fill the properties into the cells
            newRow["DocumentType"] = element.DocumentType;
            newRow["DocumentName"] = element.DocumentName;
            dataTable.Rows.Add(newRow);
        }
        // export to an xlsx file
    }
    catch (Exception e)
    {
        MessageBox.Show("error" + e.ToString());
    }
