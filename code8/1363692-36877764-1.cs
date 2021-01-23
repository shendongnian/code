    using System.IO;
    using System.Web;
    using ImageResizer;
    using Microsoft.Azure.WebJobs;
    using Microsoft.WindowsAzure.Storage.Blob;
    public class Functions
    {
        // output blolb sizes
        private static readonly int[] Sizes = { 800, 500, 250 };
        public static void ResizeImagesTask1(
            [QueueTrigger("newfileuploaded")] string filename,
            [Blob("input/{queueTrigger}", FileAccess.Read)] Stream blobStream,
            [Blob("output")] CloudBlobContainer container)
        {
            // Extract the filename  and the file extension
            var name = Path.GetFileNameWithoutExtension(filename);
            var ext = Path.GetExtension(filename);
            // Get the mime type to set the content type
            var mimeType = MimeMapping.GetMimeMapping(filename);
            foreach (var width in Sizes)
            {
                // Set the position of the input stream to the beginning.
                blobStream.Seek(0, SeekOrigin.Begin);
                // Get the output stream
                var outputStream = new MemoryStream();
                ResizeImage(blobStream, outputStream, width);
                // Get the blob reference
                var blob = container.GetBlockBlobReference($"{name}-w{width}.{ext}");
                // Set the position of the output stream to the beginning.
                outputStream.Seek(0, SeekOrigin.Begin);
                blob.UploadFromStream(outputStream);
                // Update the content type =>  don't know if required
                blob.Properties.ContentType = mimeType;
                blob.SetProperties();
            }
        }
        private static void ResizeImage(Stream input, Stream output, int width)
        {
            var instructions = new Instructions
            {
                Width = width,
                Mode = FitMode.Carve,
                Scale = ScaleMode.Both
            };
            var imageJob = new ImageJob(input, output, instructions);
            // Do not dispose the source object
            imageJob.DisposeSourceObject = false;
            imageJob.Build();
        }
    }
