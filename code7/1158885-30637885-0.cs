    String dst = dataDir + @"ImportedCustomObjects.xlsx";
    
    // Instantiate a new Workbook
    Workbook book = new Workbook();
    // Clear all the worksheets
    book.Worksheets.Clear();
    // Add a new Sheet "Data";
    Worksheet sheet = book.Worksheets.Add("Data");
    
    // Define List of custom objects
    List<ChildAccountDetails> list = new List<ChildAccountDetails>();
    // Add data to the list of objects
    list.Add(new ChildAccountDetails() { Name = "Saqib", Phone = "123-123-1234" });
    list.Add(new ChildAccountDetails() { Name = "John", Phone = "111-000-1234" });
    
    // Manually add the row titles
    sheet.Cells["A1"].PutValue("First Name");
    sheet.Cells["B1"].PutValue("Phone Number");
                
    // We pick a few columns not all to import to the worksheet
    sheet.Cells.ImportCustomObjects((System.Collections.ICollection)list,
    new string[] { "Name", "Phone" }, // Field name must match the property name in class
    false, // Don't show the field names
    1, // Start at second row
    0,
    list.Count,
    true,
    "dd/mm/yyyy",
    false);
    
    // Save
    book.Worksheets[0].AutoFitColumns();
    book.Save(dst);
