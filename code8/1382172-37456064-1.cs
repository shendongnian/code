    private void btnFillList_Click(object sender, RoutedEventArgs e)
    {
        // set the ItemsSource for ctlList with List<Folders> instead of List<string>:
        var items1 = new List<Folders>();
        string sSQL = @"SELECT [Foldername],[Path] FROM Folders";
        ISQLiteStatement dbState = dbConnection.Prepare(sSQL);
        while (dbState.Step() == SQLiteResult.ROW)
        {
            string sFoldername = dbState["Foldername"] as string;
            string sPath = dbState["Path"] as string;
            Folders folder = new Folders() { Foldername = sFoldername, Path = sPath };
            items1.Add(folder);
            ;
        }
        ctlList.ItemsSource = items1;
    }
