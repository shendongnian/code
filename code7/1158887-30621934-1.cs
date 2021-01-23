     [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        public async Task<List<string>> PostAsync()
        {
            if (Request.Content.IsMimeMultipartContent())
            {
                string uploadPath = HttpContext.Current.Server.MapPath("~/uploads");
                if (!System.IO.Directory.Exists(uploadPath))
                {
                    System.IO.Directory.CreateDirectory(uploadPath);
                }
                MyStreamProvider streamProvider = new MyStreamProvider(uploadPath);
                await Request.Content.ReadAsMultipartAsync(streamProvider);
                List<string> messages = new List<string>();
                foreach (var file in streamProvider.FileData)
                {
                    FileInfo fi = new FileInfo(file.LocalFileName);
                    messages.Add("File uploaded as " + fi.FullName + " (" + fi.Length + " bytes)");
                }
                return messages;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Request!");
                throw new HttpResponseException(response);
            }
        }
    }
        public class MyStreamProvider : MultipartFormDataStreamProvider
       {
            public MyStreamProvider(string uploadPath)
                 : base(uploadPath)
            {
          }
    public override string GetLocalFileName(HttpContentHeaders headers)
    {
        string fileName = headers.ContentDisposition.FileName;
        if (string.IsNullOrWhiteSpace(fileName))
        {
            fileName = Guid.NewGuid().ToString() + ".xls";
        }
        return fileName.Replace("\"", string.Empty);
    }
    }
