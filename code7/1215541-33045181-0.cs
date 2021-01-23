            public IList<FilePathObject> PopulateAuthorizedPathList()
            {
                IList<FilePathObject> authorizedPathList = new List<FilePathObject>();
                foreach (FilePathObject pathObject in fullPathList)
                {
                    var dir = new DirectoryInfo(pathObject.FullPath);
                    if (dir.Exists)
                    {
                        try
                        {
                            var info = dir.GetDirectories();
                            authorizedPathList.Add(pathObject);
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                        }
                    }
                }
                return authorizedPathList;
            }
