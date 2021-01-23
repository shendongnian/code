    public class MicrosoftOutlook
    {
    	private ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
    	public MicrosoftOutlook()
    	{
    		try 
            {
    			service.Url = new Uri("https://webmail.YourCompanyName.com.au/EWS/Exchange.asmx");
    
    			service.UseDefaultCredentials = true;
    
    		} catch (System.Runtime.InteropServices.COMException ex) 
            {
    		}
    	}
    	public void ListContacts() {
        // Get the number of items in the contacts folder. To limit the size of the response, request only the TotalCount property.
        ContactsFolder contactsfolder = ContactsFolder.Bind(service, WellKnownFolderName.Contacts,  new PropertySet(BasePropertySet.IdOnly, FolderSchema.TotalCount));
    	
        // Set the number of items to the number of items in the Contacts folder or 50, whichever is smaller.
        int numItems = contactsfolder.TotalCount < 50 ? contactsfolder.TotalCount : 50;
    	
        // Instantiate the item view with the number of items to retrieve from the Contacts folder.
        ItemView view = new ItemView(numItems);
    	
        // To keep the response smaller, request only the display name.
        view.PropertySet = new PropertySet(BasePropertySet.IdOnly, ContactSchema.DisplayName);
    	
        // Request the items in the Contacts folder that have the properties that you selected.
        FindItemsResults<Item>  contactItems = service.FindItems(WellKnownFolderName.Contacts, view);
    	
        // Display the list of contacts. (Note that there can be a large number of contacts in the Contacts folder.)
    		foreach (Item item in contactItems)
    		{
    			if (item is Contact)
    			{
    				Contact contact = item as Contact;
    				Console.WriteLine(contact.DisplayName);
    			}
    		}
        }
    }
