    public class Functions
    {
        //This function will get triggered/executed when a blob is created or updated on an Azure Blob container called trigger-blob-input.
        public static void TriggerAzureBlob([BlobTrigger("trigger-blob-input/{name}")] ICloudBlob blob)
        {
            Console.WriteLine("Blob name:" + blob.Name);
            //do something with the created/updated blob
        }
    }
