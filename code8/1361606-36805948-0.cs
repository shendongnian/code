    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string rd = System.Environment.GetFolderPath(Environment.SpecialFolder.Recent);
                DeleteRecentDocuments(rd);
    
                Console.ReadLine();
            }
    
            //this will delete the the files in the Recent Documents directory
            private static void DeleteRecentDocuments(string RecentDocumentsDirectory)
            {
                //this is the directory and parameter which we will pass when we call the method
                DirectoryInfo cleanRecentDocuments = new DirectoryInfo(RecentDocumentsDirectory);
    
                //try this code
                try
                {
                    //loop through the directory we use the getFiles method to collect all files which is stored in recentDocumentsFolder variable
                    foreach (FileInfo recentDocumentsFolder in cleanRecentDocuments.GetFiles())
                    {
                        //we delete all files in that directory
                        recentDocumentsFolder.Delete();
                    }
                }
                //catch any possible error and display a message
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    
    }
