    public class FileResult : ActionResult
    {
        public FileResult(string fileDownloadName, string filePath, string contentType)
        {            
            FileDownloadName = fileDownloadName;
            FilePath = filePath;
            ContentType = contentType;
        }
        public string ContentType { get; private set; }
        public string FileDownloadName { get; private set; }
        public string FilePath { get; private set; }
        public async override Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = ContentType;
            context.HttpContext.Response.Headers.Add("Content-Disposition", new[] { "attachment; filename=" + FileDownloadName });
            using (var fileStream = new FileStream(FilePath, FileMode.Open))
            {
                await fileStream.CopyToAsync(context.HttpContext.Response.Body);
            }
        }
    }
