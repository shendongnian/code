    RDOSession session = RedemptionLoader.new_RDOSession();
    session.Logon();
    RDOFolder folder = session.GetDefaultFolder(rdoDefaultFolders.olFolderContacts);
    Console.WriteLine("Extracting contacts...");
    
    foreach (RDOFolder subFolder in folder.Folders)
    {
    	if (subFolder.Name == "CAS_Notifications")
    	{
    		foreach (var rdoItem in subFolder.Items)
    		{
    			RDOContactItem contactItem = rdoItem as RDOContactItem;
    			RDODistListItem distList = rdoItem as RDODistListItem;
    			if (distList != null)
    			{
    				Console.WriteLine("Distribution List");
    				foreach (RDOAddressEntry rdoAddressEntry in distList.OneOffMembers)
    				{
    					Console.WriteLine("Name: {0}; Email: {1}", rdoAddressEntry.Name, rdoAddressEntry.SMTPAddress);
    				}
    			}
    			else if (contactItem != null)
    			{
    				Console.WriteLine("Name: {0}; Email: {1}", contactItem.FullName, contactItem.Email1Address);
    			}
    		}
    	}
    }
