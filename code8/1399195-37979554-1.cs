    directorySearcher.PropertiesToLoad.Add("name");
    directorySearcher.PropertiesToLoad.Add("physicalDeliveryOfficeName");
    directorySearcher.PropertiesToLoad.Add("pwdLastSet");
    SearchResult.Items.AddRange(
        directorySearcher.FindAll().Where(x => x.Properties != null).Select(x => new ListViewItem(new string[] {
	        x.Properties["name"] != null && x.Properties["name"].Any() 
                ? x.Properties["name"][0] 
                : String.Empty,
	        x.Properties["name"] != null && x.Properties["physicalDeliveryOfficeName"].Any() 
                 ? x.Properties["physicalDeliveryOfficeName"][0] 
                 : String.Empty,
	        x.Properties["name"] != null && x.Properties["pwdLastSet"].Any() 
                 ? x.Properties["pwdLastSet"][0] 
                 : String.Empty
	    }))
    );
