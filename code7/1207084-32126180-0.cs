           private static MemoryStream MakeZipFile(MemoryStream ms, string ZipFileName, string pass)
        {
            MemoryStream zipReturn = new MemoryStream();
            ms.Position = 0;
            try
            {
                DefaultEncryptionSettings encryptionSettings = new DefaultEncryptionSettings { Password = pass };
                // Must make an archive with leaveOpen to true
                // the ZipArchive will be made when the archive is disposed
                using (ZipArchive archive = new ZipArchive(zipReturn, ZipArchiveMode.Create, true, null, null, encryptionSettings))
                {
                    using (ZipArchiveEntry entry = archive.CreateEntry(ZipFileName))
                    {
                        using (BinaryWriter writer = new BinaryWriter(entry.Open()))
                        {
                            byte[] data = ms.ToArray();
                            writer.Write(data, 0, data.Length);
                            writer.Flush();
                        }
                    }
                }
                zipReturn.Seek(0, SeekOrigin.Begin);
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                zipReturn = null;
            }
            return zipReturn;
        }
