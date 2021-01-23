    public static string DecompressData(string val)
        {
            byte[] bytes = Convert.FromBase64String(val).ToArray();
            Stream data = new MemoryStream(bytes);
            Stream unzippedEntryStream;  
            MemoryStream ms = new MemoryStream();
            ZipArchive archive = new ZipArchive(data);
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                unzippedEntryStream = entry.Open();
                unzippedEntryStream.CopyTo(ms);  
            }
            
            string result = Encoding.UTF8.GetString(ms.ToArray());
            return result;
        }
