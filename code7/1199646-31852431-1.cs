     public static Task<bool> ZipAndSaveFileAsync(string fileToPack, string archiveName, string outputDirectory)
        {
            
            return Task.Run(() => 
            {
               var archiveNameAndPath = Path.Combine(outputDirectory, archiveName);
                using (var zip = new ZipFile())
                {
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    zip.Comment = $"This archive was created at {System.DateTime.UtcNow.ToString("G")} (UTC)";
                    zip.AddFile(fileToPack);
                    zip.Save(archiveNameAndPath);
                }
                return true;
            });
            
        }
