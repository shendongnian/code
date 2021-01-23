    // Create a TableHeaderRow.
    TableHeaderRow headerRow = new TableHeaderRow();
    
    
    // Create TableCell objects to contain 
    // the text for the header.
    TableHeaderCell headerTableCell1 = new TableHeaderCell();
    TableHeaderCell headerTableCell2 = new TableHeaderCell();
    TableHeaderCell headerTableCell3 = new TableHeaderCell();
    headerTableCell1.Text = "CustomerId";
    headerTableCell2.Text = "ProductId";
    headerTableCell3.Text = "Price";
    
    
    // Add the TableHeaderCell objects to the Cells
    // collection of the TableHeaderRow.
    headerRow.Cells.Add(headerTableCell1);
    headerRow.Cells.Add(headerTableCell2);
    headerRow.Cells.Add(headerTableCell3);
    
    // Add the TableHeaderRow as the first item 
    // in the Rows collection of the table.
    tblOrders.Rows.AddAt(0, headerRow);
