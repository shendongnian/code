    public class MyViewModel
    {
        [Required]
        public HttpPostedFileWrapper PostedFile { get; set; }
    
        [FileExtensions(Extensions = "zip,pdf")]
        public string FileName
        {
            get
            {
                if (PostedFile != null)
                    return PostedFile.FileName;
                else
                    return "";
             }
        }
    }
