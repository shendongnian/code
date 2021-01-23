    SearchFilter sf = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
                ItemView view = new ItemView(int.MaxValue);
                FindItemsResults<Item> findResults = emailService.FindItems(WellKnownFolderName.Inbox, sf, view);
                foreach (Item item in findResults)
                {
    //Get the email message
                        EmailMessage email = EmailMessage.Bind(emailService, item.Id,
                        new PropertySet(BasePropertySet.FirstClassProperties, ItemSchema.Attachments));
                        if (email != null)
                        {}
    }
    
