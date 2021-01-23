    foreach (var item in list_files)
    {
        TableRow tRow = new TableRow();
        file_table.Rows.Add(tRow);
        TableCell namecell = new TableCell(); namecell.Text = item.name; tRow.Cells.Add(namecell);
        TableCell datecell = new TableCell(); datecell.Text = item.uTC; tRow.Cells.Add(datecell);
        TableCell sizecell = new TableCell(); sizecell.Text = item.size; tRow.Cells.Add(sizecell);
    
        Button downloadButton = new Button();
        downloadButton.Text = "Download";
        downloadButton.Click += (sender, evnt) =>
        {
           //do stuff here
           GetFile(item.a, item.b)
        };
    
        // code here to call a method named GetFile with two arguments from "item"
        // e.g b.onclick ( GetFile(item.a, item.b)) ;
    
        TableCell downloadlink = new TableCell(); downloadlink.Controls.Add(downloadButton); tRow.Cells.Add(downloadlink);
    }
