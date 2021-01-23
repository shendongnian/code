            internal static Folder FolderFromPath(ExchangeService service, String FolderPath, String MailboxName)
        {
            FolderId RootFolderId = new FolderId(WellKnownFolderName.MsgFolderRoot, MailboxName);
            Folder RootFolder = Folder.Bind(service, RootFolderId);
            String[] faFldArray = FolderPath.Split('\\');
            Folder tfTargetFolder = RootFolder;
            for (int lint = 1; lint < faFldArray.Length; lint++)
            {
                if (faFldArray[lint].Length != 0)
                {
                    FolderView fview = new FolderView(1);
                    SearchFilter sf = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, faFldArray[lint]);
                    FindFoldersResults ffResult = service.FindFolders(tfTargetFolder.Id, sf, fview);
                    if (ffResult.TotalCount == 0)
                    {
                        throw new Exception("Folder Not Found");                        
                    }
                    else
                    {
                        tfTargetFolder = ffResult.Folders[0];
                    }
                }
            }
            return tfTargetFolder;
        }
          
