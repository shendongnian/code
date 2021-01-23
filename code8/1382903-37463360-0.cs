    // Starting with ClientContext, the constructor requires a URL to the 
	// server running SharePoint. 
	ClientContext context = new ClientContext("http://SiteUrl"); 
	// Assume that the web has a list named "Announcements". 
	List announcementsList = context.Web.Lists.GetByTitle("Announcements"); 
	// We are just creating a regular list item, so we don't need to 
	// set any properties. If we wanted to create a new folder, for 
	// example, we would have to set properties such as 
	// UnderlyingObjectType to FileSystemObjectType.Folder. 
	ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation(); 
	ListItem newItem = announcementsList.AddItem(itemCreateInfo); 
	newItem["Title"] = "My New Item!"; 
	newItem["Body"] = "Hello World!"; 
	newItem.Update(); 
	context.ExecuteQuery();  
