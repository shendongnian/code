    using System;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    
    namespace QueryAPI
    {
        class Program
        {
            private static Project myproject = null;
            public static QueryFolder GetMyQueriesFolder()
            {
                foreach (QueryFolder folder in myproject.QueryHierarchy)
                {
                    if (folder.IsPersonal == true)
                        return folder;
                }
                throw new Exception("Cannot find the My Queries folder");
            }
    
            public static QueryFolder AddNewFolder(string folderName)
            {
                QueryFolder folder = new QueryFolder(folderName, GetMyQueriesFolder());
                myproject.QueryHierarchy.Save();
                return folder;
            }
            static void Main(string[] args)
            {
                TfsTeamProjectCollection coll = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("Your TFS Server URI"));
                WorkItemStore store = new WorkItemStore(coll);
                myproject = store.Projects["Your project name"];
                QueryFolder myNewfolder = AddNewFolder("Your folder name");
            }
        }
    }
