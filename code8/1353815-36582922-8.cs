     string createText = @"SELECT FeedLibrary.* INTO [SelectedFeeds] 
                           FROM FeedLibrary
                           where ID=@id";
     string appendText = @"INSERT INTO SelectedFeeds
                           SELECT * FROM FeedLibrary
                           WHERE FeedLibrary.ID=@id";
    using(OleDbConnection Connection = new OleDbConnection(StrCon))
    using(OleDbCommand cmd = new OleDbCommand("", Connection))    
    {
         Connection.Open();
         var schema = Connection.GetSchema("Tables", 
                       new string[] { null, null, "SelectedFeeds", null});
         cmd.CommandText = schema.Rows.Count > 0 ? appendText : createText;
         cmd.Parameters.Add("@id", OleDbType.Integer).Value = Convert.ToInt32( frm2.FeedSelectListBox.SelectedValue);
         cmd.ExecuteNonQuery();
    }
