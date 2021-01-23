    public class HttpPostedFileWrapper : HttpPostedFileBase
    {
        private HttpPostedFile _httpPostedFile;    
   
        public HttpPostedFileWrapper(HttpPostedFile httpPostedFile) { 
            _httpPostedFile = httpPostedFile;
        }
        
        public string ContentType { get { return _httpPostedFile.ContentType; } }
        // implementation of other HttpPostedFileBase members
    }
