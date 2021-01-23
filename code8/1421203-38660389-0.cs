    private void PopulateListBox(string dname)
    {
      try
      {
        listBox1.Clear();
        string dbase = new DirectoryInfo(@"C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\Backup\");
        string dinfo = dbase + dname; //combine base folder with the folder from combobox
        var files = dinfo.GetFiles("*.bak");
        foreach (var file in files)
        {
            listBox1.Items.Add(file.Name);
        }
    }
    catch (Exception)
    {
        MessageBox.Show("The application could not find the directory to populate the List Box.");
    }
