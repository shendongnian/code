    try
    {
    	searchUser.Filter = "(&(objectClass=user)(&(givenName=" + FirstName.Text.Trim() + "*)(sn=" + LastName.Text.Trim() + "*)))";
    	searchUser.PropertiesToLoad.AddRange(new String[] { "displayName", "extensionAttribute13", "description" });
    
    	SearchResultCollection multipleResults = searchUser.FindAll();
    	DataTable userTable = new DataTable();
    
    	userTable.Columns.Add("Name", System.Type.GetType("System.String"));
    	userTable.Columns.Add("Gentiva ID", System.Type.GetType("System.Int32"));
    	userTable.Columns.Add("Location", System.Type.GetType("System.String"));
    
    	foreach (SearchResult result in multipleResults)
    	{
    		DataRow dr = userTable.NewRow();
    		DirectoryEntry de = result.GetDirectoryEntry();
    		dr["Name"] = (string)de.Properties["displayname"].Value.ToString();
    		dr["Gentiva ID"] = (int)de.Properties["extensionAttribute13"].Value;
    		dr["Location"] = (string)de.Properties["description"].Value.ToString();
    		userTable.Rows.Add(dr);
    		de.Close();
            de.Dispose(); 
           //it's very important to dispose Directory Services objects - many of them wrap COM+ resources and you will cause resource leaks if you fail to dispose
    	}
    	grdviewMultiple.DataSource = userTable;
        grdviewMultiple.DataBind();
    	//grdviewMultiple.Visibility = Visibility.Visible; you probably don't need this line
    }
    catch(ActiveDirectoryOperationException adEx)
    {
    	MessageBox.Show(adEx.ToString());
    }
