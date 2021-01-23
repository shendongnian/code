     [Serializable()]
    public class FileSerilizeObject
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Base64 { get; set; }
        public FileSerilizeObject(string filename, string extension, string base64vaulue)
        {
            FileName = filename;
            Extension = extension;
            Base64 = base64vaulue;
        }
    }
