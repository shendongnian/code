    using System;
    using Microsoft.WindowsAzure.Storage.Blob;
    public static void Run(
        string blobTrigger, Stream inputBlob, Stream outputBlob,
        CloudBlobContainer container, TraceWriter log)
    {
        log.Info($"Container name: {container.Name}");
        log.Info($"C# Blob trigger function processed {blobTrigger}");
        inputBlob.CopyTo(outputBlob);        
    }
