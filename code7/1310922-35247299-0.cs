    int x = 85;
    int y = 0;
    int currentRow = 0;
    // Loop until you have at least 85 char to grab
    while (x + y < DescriptionSplit.Length)
    {
        // Find the first white space after the 85th char
        while (x + y < DescriptionSplit.Length && 
              !char.IsWhiteSpace(DescriptionSplit[x+y]))
            x++;
        // Grab the substring and pass it to Excel for the currentRow
        InsertRowToExcel(DescriptionSplit.Substring(y, x), currentRow);
        // Prepare variables for the next loop
        currentRow++;
        y = y + x + 1;
        x = 85;
    }
    // Do not forget the last block
    if(y < DescriptionSplit.Length)
        InsertRowToExcel(DescriptionSplit.Substring(y), currentRow);
    ...
    void InsertRowToExcel(string toInsert, int currentRow)
    {
          worksheet.Rows[currentRow].Insert();    
          worksheet.Rows[currentRow].Font.Bold = false;
          worksheet.Cells[currentRow, "E"].Value = rowIndent + toInsert.Trim();
    }
