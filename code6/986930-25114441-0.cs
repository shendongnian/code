        public static byte[] GetImageFromUpload()
        {
            HttpPostedFileBase postedFile = null;
            if (HttpContext.Current.Request != null && HttpContext.Current.Request.Files.Count > 0)
                postedFile = new HttpPostedFileWrapper(HttpContext.Current.Request.Files["imageUpload"]);
            if (postedFile == null || postedFile.FileName == string.Empty) return null;
            using (Image img = Image.FromStream(postedFile.InputStream))
            {
                var file = new byte[postedFile.InputStream.Length];
                var reader = new BinaryReader(postedFile.InputStream);
                postedFile.InputStream.Seek(0, SeekOrigin.Begin);
                file = reader.ReadBytes((int)postedFile.InputStream.Length);
                return file;
            }
        }
