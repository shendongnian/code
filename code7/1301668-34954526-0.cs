     public static IList GetFiles(DriveService service, string search)
        {
            IList Files = new List();
            try
            {
                //List all of the files and directories for the current user.  
                // Documentation: https://developers.google.com/drive/v2/reference/files/list
                FilesResource.ListRequest list = service.Files.List();
                list.MaxResults = 1000;
                if (search != null)
                {
                    list.Q = search;
                }
                FileList filesFeed = list.Execute();
                //// Loop through until we arrive at an empty page
                while (filesFeed.Items != null)
                {
                    // Adding each item  to the list.
                    foreach (File item in filesFeed.Items)
                    {
                        Files.Add(item);
                    }
                    // We will know we are on the last page when the next page token is
                    // null.
                    // If this is the case, break.
                    if (filesFeed.NextPageToken == null)
                    {
                        break;
                    }
                    // Prepare the next page of results
                    list.PageToken = filesFeed.NextPageToken;
                    // Execute and process the next page request
                    filesFeed = list.Execute();
                }
            }
            catch (Exception ex) {
                // In the event there is an error with the request.
                Console.WriteLine(ex.Message);                            
            }
            return Files;
        }
