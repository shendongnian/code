    if (Request.Files.Count > 0)
        {
            var file = Request.Files[0];
            if (file.ContentLength > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    var bytes = ms.ToArray();
                }
            }
        }
