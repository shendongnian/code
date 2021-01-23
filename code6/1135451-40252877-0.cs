        public FileResult DownLoad(string filename)
        {
            var content = XFile.GetFile(filename);
            return File(content, System.Net.Mime.MediaTypeNames.Application.Zip, filename);
        }
