    this.Table = this.MigraDokument.AddSection().addTable();
    Row row = this.Table.AddRow();
    // Here I grab the cell that I want to populate later
    Cell dataCell = row.Cells[0];
    
    // Than I build the table with alle the necessary Information in it
    Table k_table = new Table();
    // adding columns and rows with 
    k_table.AddColumn();
    k_table.AddColumn();
    Row row = k_table.AddRow();
    // and populate with data
    row.Cells[0].AddParagraph("Stuff 1");
    row.Cells[1].AddParagraph("Stuff 2");
    
    // The final trick is to add it in the end to the `Elements`
    // property of the cell
    dataCell.Elements.add(k_table);
