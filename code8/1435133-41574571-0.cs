    string navigationGroupName = "New Folder Group";
    string folderName = "New Folder";
            
                                ContactsModule contactsModule = Globals.ThisAddIn.Application.ActiveExplorer()
                                    .NavigationPane
                                    .Modules
                                    .GetNavigationModule(OlNavigationModuleType.olModuleContacts) as ContactsModule;
            
                                NavigationGroup navigationGroup = contactsModule.NavigationGroups.Create(navigationGroupName);
            
                                Folder contactFolder = (Folder) Globals.ThisAddIn.Application.Session
                                    .GetDefaultFolder(OlDefaultFolders.olFolderContacts)
                                    .Folders
                                    .Add(folderName, OlDefaultFolders.olFolderContacts);
            
                                navigationGroup.NavigationFolders.Add(contactFolder);
