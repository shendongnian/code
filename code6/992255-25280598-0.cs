                ItemView ItemView = new ItemView(1);
            SearchFilter cntGroup = new SearchFilter.IsEqualTo(ItemSchema.ItemClass, "IPM.DistList");
            SearchFilter cntGroupName = new SearchFilter.IsEqualTo(ContactGroupSchema.DisplayName, "Test Contact Group");
            SearchFilter sfCol = new SearchFilter.SearchFilterCollection(LogicalOperator.And) { cntGroup, cntGroupName };
            FolderId ContactFolder = new FolderId(WellKnownFolderName.Contacts, "user@domain.com");
            FindItemsResults<Item> fiCntResults = service.FindItems(ContactFolder, sfCol, ItemView);
            if (fiCntResults.Items.Count == 1)
            {
                ContactGroup contactGroup = (ContactGroup)fiCntResults.Items[0];
                Contact Contact2 = new Contact(service);
                Contact2.EmailAddresses[EmailAddressKey.EmailAddress1] = new EmailAddress("blah@blah.dk");
                Contact2.Subject = "Blah";
                Contact2.Save();
                GroupMember gm = new GroupMember(Contact2,EmailAddressKey.EmailAddress1);             
                
                contactGroup.Members.Add(gm);
                contactGroup.Update(ConflictResolutionMode.AlwaysOverwrite);
            }
