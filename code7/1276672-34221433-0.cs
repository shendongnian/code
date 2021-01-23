                using (var ms = new MemoryStream())
                {
                    using (var zipArchive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                    {
                        foreach (var attachment in byteList)
                        {
                            var entry = zipArchive.CreateEntry(attachment.Key);
    
                            using (var originalFile = new MemoryStream(attachment.Value))
                            {
                                using (var zipEntryStream = entry.Open())
                                {
                                    originalFile.CopyTo(zipEntryStream);
                                }
                            }
                        }
                    }
    
                    Response.ContentType = "application/zip";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + "Reports.zip");
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.CopyTo(Response.OutputStream);
                    Response.End();
