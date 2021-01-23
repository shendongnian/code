    public class UploadForm
    {
        public HttpPostedFileBase file1 {get;set;}
        
        public IEnumerable<HttpPostedFileBase> files {get;set;}
    }
