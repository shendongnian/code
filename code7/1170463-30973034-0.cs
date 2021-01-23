    fileNames.AsParallel().ForAll(str =>
                {
                    var files = Directory.GetFiles(folderToCheckForFileName, str, SearchOption.AllDirectories);
                    files.AsParallel().ForAll(file =>
                    {
                        if (!string.IsNullOrEmpty(file))
                        {
                            string combinedPath = Path.Combine(newTargetDirectory, Path.GetFileName(file));
                            if (!File.Exists(combinedPath))
                            {
                                File.Copy(file, combinedPath);
                            }
                        }
                    });
                });
