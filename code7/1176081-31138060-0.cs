    /// <summary>
      /// Retrieve a list of File resources.
      /// </summary>
      /// <param name="service">Drive API service instance.</param>
      /// <returns>List of File resources.</returns>
      public static List<File> retrieveAllFiles(DriveService service) {
        List<File> result = new List<File>();
        FilesResource.ListRequest request = service.Files.List();
    
        do {
          try {
            FileList files = request.Execute();
    
            result.AddRange(files.Items);
            request.PageToken = files.NextPageToken;
          } catch (Exception e) {
            Console.WriteLine("An error occurred: " + e.Message);
            request.PageToken = null;
          }
        } while (!String.IsNullOrEmpty(request.PageToken));
        return result;
      }
