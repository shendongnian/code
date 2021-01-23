    string DBPath = Application.StartupPath;
            OleDbConnection Connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+DBPath+@"\DataBase\SampleFeeds.accdb");
            OleDbDataAdapter DataA = new OleDbDataAdapter("Select * from FeedLibrary where category='Grass / Legume'", Connection);
            DataTable Dtable = new DataTable();
            DataA.Fill(Dtable);
            frm2.FeedSelectListBox .DataSource = Dtable;
