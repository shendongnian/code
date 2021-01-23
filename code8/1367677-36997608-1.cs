    List<string> dblist = Directory.GetFiles(foldername,"*.mdb").ToList();
    foreach (var db in dblist)
    {
         Using (var connection=new OleDbConnection("Data Source=" + db + ";Persist Security Info=False;Provider=Microsoft.Jet.OLEDB.4.0;"))
         {
             //my query ...
         }
    }
