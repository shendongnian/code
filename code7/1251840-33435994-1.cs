    ItemView view = new ItemView(1);
    String searchstring = "<1031208507.471.1446200157453.JavaMail.test>";
    SearchFilter.IsEqualTo filter = 
       new SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, searchstring);
    
    FindItemsResults<Item> findResults = 
       service.FindItems(WellKnownFolderName.Inbox, filter, view);
