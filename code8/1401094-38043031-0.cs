    if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await file.InputStream.CopyToAsync(ms);
                        var bytes = ms.ToArray();
                    }
                }
            }
