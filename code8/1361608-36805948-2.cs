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
                        File.Delete(RecentDocumentsDirectory + recentDocumentsFolder);
    
                    }
                }
                //catch any possible error and display a message
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
