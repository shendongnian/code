                foreach (var subDir in Directory.EnumerateDirectories(root))
                {
                    try
                    {
                        SearchAccessibleFilesNoDistinct(subDir, files);
                        files.Add(subDir);  <--- remove this line
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        // ...
                    }
                }
