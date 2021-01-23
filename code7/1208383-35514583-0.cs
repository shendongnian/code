    private void CreateSampleTable(DocX document)
    {
        int rowsCount = 10;
        int columnsCount = 20;
        int columnWidth = 30;
    
        Table sampleTable = document.AddTable(rowsCount, 1);
        foreach (Row row in sampleTable.Rows)
        {
            row.Cells[0].Width = columnWidth;
        }
    
        for (int colIndex = 1; colIndex < columnsCount; colIndex++)
        {
            sampleTable.InsertColumn(colIndex);
            foreach (Row row in sampleTable.Rows)
            {
                row.Cells[colIndex].Width = columnWidth;
            }
        }
    
        Paragraph par = document.InsertParagraph();
        par.InsertTableBeforeSelf(sampleTable);
    }
