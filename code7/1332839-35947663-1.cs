    // Set the view to show details.
    listView1.View = View.Details;
    // Display check boxes.
    listView1.CheckBoxes = true;
    listView1.FullRowSelect = true;
    listView1.MultiSelect = false;
    // Set the handler for tracking the check on files and their order
    listView1.ItemCheck += onCheck;
    // Now extract the files, (path fixed here, but you could add a 
    // FolderBrowserDialog to allow changing folders....
    DirectoryInfo di = new DirectoryInfo(@"d:\temp");
    FileInfo[] entries = di.GetFiles("*.*");
    
    // Fill the listview with files and some of their properties
    ListViewItem item = null;
    foreach (FileInfo entry in entries)
    {
        item = new ListViewItem(new string[] { entry.Name, entry.LastWriteTime.ToString(), entry.Length.ToString()} );
        listView1.Items.Add(item);
    }            
    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);                        
    
    // Create columns for the items and subitems.
    // Width of -2 indicates auto-size.
    listView1.Columns.Add("File name", -2, HorizontalAlignment.Left);
    listView1.Columns.Add("Last Write Time2", -2, HorizontalAlignment.Left);
    listView1.Columns.Add("Size", -2, HorizontalAlignment.Left);
