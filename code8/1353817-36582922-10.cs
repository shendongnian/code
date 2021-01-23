     // First query, this creates the target SelectedFeeds but fail if it exists
     string createText = @"SELECT FeedLibrary.* INTO [SelectedFeeds] 
                           FROM FeedLibrary
                           where ID=@id";
     // Second query, it appends to SelectedFeeds but it should exists
     string appendText = @"INSERT INTO SelectedFeeds
                           SELECT * FROM FeedLibrary
                           WHERE FeedLibrary.ID=@id";
    using(OleDbConnection Connection = new OleDbConnection(StrCon))
    using(OleDbCommand cmd = new OleDbCommand("", Connection))    
    {
         Connection.Open();
         // Get info about the SelectedFeeds table....
         var schema = Connection.GetSchema("Tables", 
                       new string[] { null, null, "SelectedFeeds", null});
         // Choose which command to execute....
         cmd.CommandText = schema.Rows.Count > 0 ? appendText : createText;
         // Parameter @id is the same for both queries
         cmd.Parameters.Add("@id", OleDbType.Integer).Value = Convert.ToInt32( frm2.FeedSelectListBox.SelectedValue);
         cmd.ExecuteNonQuery();
    }
