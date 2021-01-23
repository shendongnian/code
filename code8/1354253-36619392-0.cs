        [HttpGet]
        public void Export()
        {
            var response = Context.Current.Response;
            var writeStream = response.OutputStream;
            var name      = "export.exe";
            // Create the zip archive in memory
            using (var archive = new Ionic.Zip.ZipFile())
            {
                archive.Comment = "Self extracting export";
                archive.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                using (var memoryStream = new MemoryStream())
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    streamWriter.WriteLine("Hello World");
                    streamWriter.Flush();
                    archive.AddEntry("testfile.txt", memoryStream.ToArray());
                }
                // Write sfx file to temp folder on server
                archive.SaveSelfExtractor(name, new Ionic.Zip.SelfExtractorSaveOptions
                {
                    Flavor = Ionic.Zip.SelfExtractorFlavor.ConsoleApplication,
                    Quiet = true,
                    DefaultExtractDirectory = "\\temp",
                    SfxExeWindowTitle = "Export",
                    ExtractExistingFile = Ionic.Zip.ExtractExistingFileAction.OverwriteSilently,
                    RemoveUnpackedFilesAfterExecute = false
                });
                // Read file back and output to response
                using (var fileStream = new FileStream(name, FileMode.Open))
                {
                    byte[] buffer = new byte[4000];
                    int n = 1;
                    while (n != 0)
                    {
                        n = fileStream.Read(buffer, 0, buffer.Length);
                        if (n != 0)
                            writeStream.Write(buffer, 0, n);
                    }
                }
                // Delete the temporary file
                if (File.Exists(name))
                {
                    try { File.Delete(name); }
                    catch (System.IO.IOException exc1)
                    {
                        Debug.WriteLine("Warning: Could not delete file: {0} {1}", name, exc1);
                    }
                }
            }
            response.AddHeader("Content-Disposition", "attachment; filename=" + name);
            response.AddHeader("Content-Description", "File Transfer");
            response.AddHeader("Content-Transfer-Encoding", "binary");
            response.ContentType = "application/exe";
            response.Flush();
            response.Close();
            response.End();
        }
