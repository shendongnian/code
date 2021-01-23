    	Folder.Bind(Service, WellKnownFolderName.Inbox);
    
    	var sf = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
    
    	//ItemView limits the results to numOfMails2Fetch items
    	var foundItems = Service.FindItems(WellKnownFolderName.Inbox, sf, new ItemView(numOfMails2Fetch)).ToList();
    
    	// fetches the body of each email and assigns it to each EmailMessage
    	Service.LoadPropertiesForItems(foundItems,PropertySet.FirstClassProperties);
    
    	//List<EmailMessage> emailsList = new List<EmailMessage>();
    	foreach(var item in foundItems)
    	{
    	  var iEM = item as EmailMessage;
    	  if(iEM != null)
    		  iEM.IsRead = true;
    	  //emailsList.Add(iEM);
    	}
    
    	// Batch update all the emails
    	var response = Service.UpdateItems(foundItems, WellKnownFolderName.Inbox, ConflictResolutionMode.AutoResolve, MessageDisposition.SaveOnly, null);
    
    	return foundItems;
    }
