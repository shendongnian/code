    List<string> itemlist = new List<string>();
    foreach (SearchResult sResultSet in dSearch.FindAll())
    {                
         itemlist.(GetProperty(sResultSet, "sn") + ", " + GetProperty(sResultSet, "givenName"));
    }
    itemlist.Sort();
    foreach (string s in itemlist)
    { 
        cmb_name.Items.Add(s);
    }
