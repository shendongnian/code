    using System.Linq;
    using Microsoft.SharePoint.Client;
    
    namespace SharePoint.Client.Extensions
    {
        public static class ListCollectionExtensions
        {
    
            /// <summary>
            /// Get list items located under specific folder 
            /// </summary>
            /// <param name="list"></param>
            /// <param name="relativeFolderUrl"></param>
            /// <returns></returns>
            public static ListItemCollection GetListItems(this List list, string relativeFolderUrl)
            {
                var ctx = list.Context;
                if (!list.IsPropertyAvailable("RootFolder"))
                {
                    ctx.Load(list.RootFolder, f => f.ServerRelativeUrl);
                    ctx.ExecuteQuery();
                }
                var folderUrl = list.RootFolder.ServerRelativeUrl + "/" + relativeFolderUrl;
                var qry = CamlQuery.CreateAllItemsQuery();
                qry.FolderServerRelativeUrl = folderUrl;
                var items = list.GetItems(qry);
                return items;
            }
        }
    }
