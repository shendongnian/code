        public class ImageViewModel
       {
        public int ImageID { get; set; }
        public int ImageSize { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }
        public HttpPostedFileBase File { get; set; }
       }
