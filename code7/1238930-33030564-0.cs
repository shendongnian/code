             SearchFilter AllItemsSF = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "AllItems");
            ExtendedPropertyDefinition PR_FOLDER_TYPE = new ExtendedPropertyDefinition(13825, MapiPropertyType.Integer);
            SearchFilter SearchFoldersOnly = new SearchFilter.IsEqualTo(PR_FOLDER_TYPE, 2);
            SearchFilter sfCol = new SearchFilter.SearchFilterCollection(LogicalOperator.And) { AllItemsSF, SearchFoldersOnly };
            FolderId SearchRootId = new FolderId(WellKnownFolderName.Root, MailboxYouWantToAccess);
            FolderView fvFolderView = new FolderView(100);
            fvFolderView.Traversal = FolderTraversal.Deep;
            FindFoldersResults ffResults = service.FindFolders(SearchRootId, sfCol, fvFolderView);
            if (ffResults.Folders.Count == 1)
            {
                Console.WriteLine(ffResults.Folders[0].UnreadCount);
            }
