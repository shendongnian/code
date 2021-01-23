    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    // Class to contain list of blob files info
    public class BlobFileInfo {
      public string FileName { get; set; }
      public string BlobPath { get; set; }
      public string BlobFilePath { get; set; }
      public IListBlobItem Blob { get; set; }
    }
    public static class BlobHelper {
    // Load blob container
    public static CloudBlobContainer GetBlobContainer(string containerName) {
      var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
      var blobClient = storageAccount.CreateCloudBlobClient();
      var container = blobClient.GetContainerReference(containerName);
      return container;
    }
    // Get recursive list of files
    public static IEnumerable<BlobFileInfo> ListFolderBlobs(string containerName, string directoryName) {
      var blobContainer = GetBlobContainer(containerName);
      var blobDirectory = blobContainer.GetDirectoryReference(directoryName);
      var blobInfos = new List<BlobFileInfo>();
      var blobs = blobDirectory.ListBlobs().ToList();
      foreach (var blob in blobs) {
        if (blob is CloudBlockBlob) {
          var blobFileName = blob.Uri.Segments.Last().Replace("%20", " ");
          var blobFilePath = blob.Uri.AbsolutePath.Replace(blob.Container.Uri.AbsolutePath + "/", "").Replace("%20", " ");
          var blobPath = blobFilePath.Replace("/" + blobFileName, "");
          blobInfos.Add(new BlobFileInfo {
            FileName = blobFileName,
            BlobPath = blobPath,
            BlobFilePath = blobFilePath,
            Blob = blob
          });
        }
        if (blob is CloudBlobDirectory) {
          var blobDir = blob.Uri.OriginalString.Replace(blob.Container.Uri.OriginalString + "/", "");
          blobDir = blobDir.Remove(blobDir.Length - 1);
          var subBlobs = ListFolderBlobs(containerName, blobDir);
          blobInfos.AddRange(subBlobs);
        }
      }
      return blobInfos;
    }
    }
