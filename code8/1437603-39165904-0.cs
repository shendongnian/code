    var obj = new MovieListModel()
                    {
                        FileName = fi.Name,
                        FilePathList = new List<string>(){ obj, whatever...},
                        Count = 1,
                        Extension = fi.Extension,
                        Size = Helper.FormatBytes(fi.Length),
                        CreatedTime = fi.CreationTime,
                        ModifiedTime = File.GetLastWriteTime(item)
                    };
