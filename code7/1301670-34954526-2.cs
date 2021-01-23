    using Google.Apis.Drive.v2;
    using Google.Apis.Drive.v2.Data;
    // ...
    public class MyClass {
    // ...
    /// <summary>
    /// Print files belonging to a folder.
    /// </summary>
    /// <param name="service">Drive API service instance.</param>
    /// <param name="folderId">ID of the folder to print files from</param>
    public static void PrintFilesInFolder(DriveService service,
      String folderId) {
    ChildrenResource.ListRequest request = service.Children.List(folderId);
    do {
      try {
        ChildList children = request.Execute();
        foreach (ChildReference child in children.Items) {
          Console.WriteLine("File Id: " + child.Id);
        }
        request.PageToken = children.NextPageToken;
      } catch (Exception e) {
        Console.WriteLine("An error occurred: " + e.Message);
        request.PageToken = null;
      }
      } while (!String.IsNullOrEmpty(request.PageToken));
      }
      // ...
      }
