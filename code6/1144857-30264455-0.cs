	using System;
	using Amazon.S3;
	using Amazon.S3.Transfer;
	using Microsoft.WindowsAzure.Storage;
	using Microsoft.WindowsAzure.Storage.Auth;
	using Microsoft.WindowsAzure.Storage.Blob;
	namespace Sample
	{
		class UploadFileFromAzureToS3
		{
			static string existingBucketName = "[Bucket name]";
			static string keyName = "[Your object key]";
			static void Main(string[] args)
			{
				TransferUtility fileTransferUtility = new TransferUtility(new AmazonS3Client(Amazon.RegionEndpoint.USEast1));
				
				CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=[Storage Account Name];AccountKey=[Storage Account Primary Key]");
				CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
				CloudBlobContainer container = blobClient.GetContainerReference("[Your container]");
				CloudBlockBlob blockBlob = container.GetBlockBlobReference("[File Name]");
				using (var fileToUpload = new MemoryStream())
				{
					blockBlob.DownloadToStream(fileToUpload);
					fileTransferUtility.Upload(fileToUpload, existingBucketName, keyName);
				}
			}
		}
	}
