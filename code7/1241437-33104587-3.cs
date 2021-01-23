    using System;
    using Microsoft.SharePoint.Client;
    
    namespace SharePoint.ClientExtensions
    {
        public static class ListExtensions
        {
    
    
            /// <summary>
            /// Create Folder in List
            /// </summary>
            /// <param name="list"></param>
            /// <param name="folderUrl"></param>
            /// <returns></returns>
            public static Folder CreateFolder(this List list, string folderUrl)
            {
                if (string.IsNullOrEmpty(folderUrl))
                    throw new ArgumentNullException("folderUrl");
                if (!list.IsPropertyAvailable("RootFolder"))
                {
                    list.Context.Load(list.RootFolder);
                    list.Context.ExecuteQuery();
                }
                return CreateFolderInternal(list.RootFolder,folderUrl);
            }
    
            private static Folder CreateFolderInternal(Folder parentFolder, string folderUrl)
            {  
                var folderUrlParts = folderUrl.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var curFolder = parentFolder.Folders.Add(folderUrlParts[0]);
                parentFolder.Context.Load(curFolder);
                parentFolder.Context.ExecuteQuery();
                if (folderUrlParts.Length > 1)
                {
                    var subFolderUrl = string.Join("/", folderUrlParts, 1, folderUrlParts.Length - 1);
                    return CreateFolderInternal(curFolder, subFolderUrl);
                }
                return curFolder;
            }
        }
    }
   
