     SearchFilter sf = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
                ItemView view = new ItemView(int.MaxValue);
                FindItemsResults<Item> findResults = emailService.FindItems(WellKnownFolderName.Inbox, sf, view);
                foreach (EmailMessage email in findResults)
                {}
