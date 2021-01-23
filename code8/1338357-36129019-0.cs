            using System.IO;
        private static void DisplayIcon(string extension)
        {
            string extensionArray = { "avi", "bmp", "css", "doc", "gif", "htm", "jpg", "js", "mov", "mp3", "mp4", "mpg", "pdf", "php", "png", "ppt", "rar", "txt", "xls", "xml", "zip" };
            var ext = System.IO.Path.GetExtension("");
            for (int i = 0; i < extensionArray.Count(); i++)
            {
                if (extensionArray[i].Equals(extension))
                {
                    // Appropriately return extension here
                }
            }
        }
