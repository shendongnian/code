    // You create a table with 5 columns
    PdfPTable mTablePerson2 = new PdfPTable(5);
    // You start the first row:
    mTablePerson2.AddCell("Name");     // column 1
    mTablePerson2.AddCell("Age");      // column 2
    mTablePerson2.AddCell(secondNV);   // column 3
    mTablePerson2.AddCell(secondAgeV); // column 4
    // You add the table to the document:
    document.Add(mTablePerson2);
