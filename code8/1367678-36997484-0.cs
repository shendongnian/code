    using (var compressedFileStream = new MemoryStream())
            {
                using (var zipArchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Update, false))
                {
                    foreach (Result result in results)
                    {
                        string fileName = String.Format("{0}-{1}.bin", id >> 16, result.Id);
                        var zipEntry = zipArchive.CreateEntry(fileName);
                        using (var originalFileStream = new MemoryStream(result.Value))
                        {
                            using (var zipEntryStream = zipEntry.Open())
                            {
                                originalFileStream.CopyTo(zipEntryStream);
                            }
                        }
                    }
                }
                return File(compressedFileStream.ToArray(), "application/zip", string.Format("Download_{0:ddMMyyy_hhmm}.zip", DateTime.Now));
