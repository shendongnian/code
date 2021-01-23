    using System;
    using System.Collections.ObjectModel;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    
    using System.IO;
    
    namespace TFS_Path_Extraction
    {
        class Program
        {
            static void Main(string[] args)
            {
                TeamFoundationServer server = new TeamFoundationServer("<TFS path of folders you want>");
                VersionControlServer version = server.GetService(typeof(VersionControlServer)) as VersionControlServer;
    
                ItemSet items = version.GetItems(@"$\", RecursionType.Full);
                foreach (Item item in items.Items)
                {
                    if (item.ItemType == ItemType.Folder)
                    {
                        System.Console.WriteLine(item.ServerItem);
                    }
                }
                Console.Read();
            }
        }
    }
