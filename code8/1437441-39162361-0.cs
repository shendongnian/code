    foreach (var dir in System.IO.Directory.GetDirectories(sourcePath))
                {
                    var dirInfo = new System.IO.DirectoryInfo(dir);
                    System.IO.Directory.CreateDirectory(System.IO.Path.Combine(targetPath, dirInfo.Name));
                    foreach (var file in System.IO.Directory.GetFiles(dir))
                    {
                        var fileInfo = new System.IO.FileInfo(file);
                        fileInfo.CopyTo(System.IO.Path.Combine(targetPath, dirInfo.Name, fileInfo.Name));
                    }
                };
