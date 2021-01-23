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
    		if (result.GetDirectoryEntry().Properties != null)
    		{
    			if(result.GetDirectoryEntry().Properties["displayname"].Value==null)
    			{
    				dr["Name"] = "";
    			}
    			else
    			{
    			  dr["Name"] = (string)de.Properties["displayname"].Value.ToString();
    			}			
    			if (result.GetDirectoryEntry().Properties["extensionAttribute"].Value == null)
    			{
                    dr["Gentiva ID"] = DBNull.Value; 
    			}
    			else
    			{
    				dr["Gentiva ID"] = (int)de.Properties["extensionAttribute13"].Value;
    			}
    			if (result.GetDirectoryEntry().Properties["description"].Value == null)
    			{
    				dr["Location"] = "";
    			}
    			else
    			{
    				dr["Location"] = (string)de.Properties["description"].Value.ToString();
    			}
    
    		}		
            userTable.Rows.Add(dr);
        }
    	de.Close();
    	de.Dispose();
        grdviewMultiple.ItemsSource = userTable.AsDataView();
        grdviewMultiple.Visibility = Visibility.Visible;
    }
    catch(ActiveDirectoryOperationException adEx)
    {
        MessageBox.Show(adEx.ToString());
    }
