	using Microsoft.WindowsAzure.Storage;
	using Microsoft.WindowsAzure.Storage.Blob;
	using Microsoft.WindowsAzure.Storage.DataMovement;
	namespace BlobUploader
	{
		public class Uploader
		{
			public string ConnectionString { get; set; }
			public string ContainerName { get; set; }
			public string BlobName { get; set; }
				
			public void UploadFile(string filePath) {
				
				CloudStorageAccount account = CloudStorageAccount.Parse(ConnectionString);
				CloudBlobClient blobClient = account.CreateCloudBlobClient();
				CloudBlobContainer blobContainer = blobClient.GetContainerReference(ContainerName);
				blobContainer.CreateIfNotExists();
				CloudBlockBlob destinationBlob = blobContainer.GetBlockBlobReference(BlobName);
				TransferManager.Configurations.ParallelOperations = 64;
				TransferContext context = new TransferContext();
				context.ProgressHandler = new Progress<TransferProgress>((progress) => {
					Console.WriteLine("Bytes uploaded: {0}", progress.BytesTransferred);
				});
				var task = TransferManager.UploadAsync(filePath, destinationBlob, null, context, CancellationToken.None);
				task.Wait();   
			}
		}
	}
