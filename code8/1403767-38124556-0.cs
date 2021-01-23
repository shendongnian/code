    var trash = Path.Combine(_temporalPath, "Trash");
            try
            {
                var zip = new ICSharpCode.SharpZipLib.Zip.FastZip();
                Directory.CreateDirectory(trash);
                zip.ExtractZip(_origin, trash, null);
                var gzip = Directory.GetFiles(trash, "*.gz")[0];
                UnGzFile(gzip, Path.Combine(trash, Path.GetFileNameWithoutExtension(gzip)));
                File.Delete(gzip);
                var tar = Directory.GetFiles(trash, "*.tar")[0];
                var stream = File.OpenRead(tar);
                var tarArchive = ICSharpCode.SharpZipLib.Tar.TarArchive.CreateInputTarArchive(stream);
                tarArchive.ExtractContents(trash);
                tarArchive.Close();
                stream.Close();
                File.Delete(tar);
            }
            catch (Exception ex)
            {
                //IGNORE
            }
