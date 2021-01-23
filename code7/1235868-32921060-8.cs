     var folders = new DataTable(); 
     folders.Columns.Add("Status");
     folders.Columns.Add("Folder");
     foreach (var folder in Directory.EnumerateDirectories(@"c:\temp"))
     {
        var row = folders.NewRow();
        folders.Rows.Add(row);
        row["Folder"] = folder;
     }
     this.folders.DataSource = folders;
