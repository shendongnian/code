    using Amazon.S3.Transfer;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Amazon.S3.AmazonS3Client();
            using (var ms = new MemoryStream()) // Load the data into memorystream from a data source other than a file
            {
                using (var transferUtility = new TransferUtility(client))
                {
                    transferUtility.Upload(ms, "bucket", "key");
                }
            }
        }
    }
 
