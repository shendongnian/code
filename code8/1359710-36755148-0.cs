        foreach (var blobItem in container.ListBlobs(useFlatBlobListing: true))
        {
          Console.WriteLine(blobItem.Parent.Uri.MakeRelativeUri(blobItem.Uri));
          //Segments Method
          Console.WriteLine(blobItem.Uri.Segments.Last());
          //Substring Method
          string filename = blobItem.AbsolutUri.Substring(det.Filename.LastIndexOf("/") + 1)
          Console.WriteLine(fileName);
        }
