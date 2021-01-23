            SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
            PropertySet FindItemPropertySet = new PropertySet(BasePropertySet.IdOnly);
  
            ItemView view = new ItemView(999);
            view.PropertySet = FindItemPropertySet;
            PropertySet GetItemsPropertySet = new PropertySet(BasePropertySet.FirstClassProperties);
            GetItemsPropertySet.RequestedBodyType = BodyType.Text;
            
            FindItemsResults<Item> emailMessages = null;
            do
            {
                emailMessages = service.FindItems(WellKnownFolderName.Inbox, searchFilter, view);
                if (emailMessages.Items.Count > 0)
                {
                    service.LoadPropertiesForItems(emailMessages.Items, GetItemsPropertySet);
                    foreach (Item Item in emailMessages.Items)
                    {
                        Console.WriteLine(Item.Body.Text);
                    }
                }
            } while (emailMessages.MoreAvailable);
