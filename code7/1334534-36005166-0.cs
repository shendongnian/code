      // Files has 25 PDF
            var Files = Folder.GetFileToPublicFolder(Folder.srcFolder);
            int _skip = 0;
            foreach (FileInfo file in Files)
            {
                // Get 10 PDF in Files
                List<FileInfo> files = Files.Skip(_skip).Take(10).ToList();
                // Process the 10 PDF
                foreach (var item in files)
                {
                    File.Move(Path.Combine(Folder.srcFolder, item.Name), Path.Combine(Folder.tmpFolder, item.Name));
                }
                files = null;
                ProcessParallelThread(e);
                _skip = _skip + 10;
            }
