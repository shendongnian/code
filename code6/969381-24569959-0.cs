    private Items _inboxItems;
    
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
    	MAPIFolder inboxFolder = Application.GetNamespace("MAPI").GetDefaultFolder(OlDefaultFolders.olFolderInbox);
    	_inboxItems = inboxFolder.Items;
    
    	_inboxItems.ItemAdd += InboxItems_ItemAdd;
    
    	Marshal.ReleaseComObject(inboxFolder);
    }
    
    private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
    {
    	Marshal.ReleaseComObject(_inboxItems);
    }
    
    private void InboxItems_ItemAdd(object item)
    {    
        if (item is MailItem)
        {
            // Add your code here        
        }
    }
