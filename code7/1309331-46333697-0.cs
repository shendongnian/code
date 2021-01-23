    List<SearchFilter> searchFilterCollection = new List<SearchFilter>();
    searchFilterCollection.Add(new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
    SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, searchFilterCollection);
    ItemView view = new ItemView(100);
    view.PropertySet = new PropertySet(BasePropertySet.IdOnly, ItemSchema.Subject);
    view.Traversal = ItemTraversal.Shallow;
    FindItemsResults<Item> findResults;
    findResults = service.FindItems(new FolderId(WellKnownFolderName.Inbox, new Mailbox(user)), searchFilter, view);    
    var itemIds = from item in findResults
                  select item.Id;
    service.MoveItems(itemIds,
                        (Folder.Bind(service, WellKnownFolderName.MsgFolderRoot)
                        .FindFolders(new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "Test"), new FolderView(1))
                        .FirstOrDefault(x => x.DisplayName == "Test")).Id);
