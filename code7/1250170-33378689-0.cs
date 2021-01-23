    [Serializable()]
    public class FileSerilizeObject 
        {
            [Serializable()]
            public static string FileName { get; set; }
            [Serializable()]
            public static string Extension { get; set; }
            [Serializable()]
            public static string Base64 { get; set; } 
    
            public FileSerilizeObject(string filename, string extension, string base64vaulue)
            {
                FileName = filename;
                Extension = extension;
                Base64 = base64vaulue;
            }
    
        }
    }
