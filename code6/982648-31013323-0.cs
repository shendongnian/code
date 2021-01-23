    Document document = new Document();
    
    Section section = document.AddSection();
    section.PageSetup.PageFormat = PageFormat.A4;
    
    Table table = section.AddTable();
    
    int sectionWidth = section.PageSetup.PageWidth - section.PageSetup.LeftMargin - section.PageSetup.RightMargin;
    int columnWidth = sectionWidth / 2;
    
    Column column = table.AddColumn();
    column.Width = columnWidth;
    Column column2 = table.AddColumn();
    column2.Width = columnWidth;
    
    Row row = table.AddRow();
    row.Cells[0].AddParagraph("Row 1, Column A");
    row.Cells[1].AddParagraph("Row 1, Column B");
