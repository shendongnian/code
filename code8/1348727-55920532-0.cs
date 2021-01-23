    private IList<string> GetFullPath(Google.Apis.Drive.v3.Data.File file, IList<Google.Apis.Drive.v3.Data.File> files)
            {
                IList<string> Path = new List<string>();
    
                if (file.Parents == null || file.Parents.Count == 0)
                {
                    return Path;
                }
                Google.Apis.Drive.v3.Data.File Mainfile = file;
    
                while (GetParentFromID(file.Parents[0], files) != null)
                {
                    Path.Add(GetFolderNameFromID(GetParentFromID(file.Parents[0], files).Id, files));
                    file = GetParentFromID(file.Parents[0], files);
                }
                return Path;
            }
    private Google.Apis.Drive.v3.Data.File GetParentFromID(string FileID, IList<Google.Apis.Drive.v3.Data.File> files)
            {
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        if (file.Parents != null && file.Parents.Count > 0)
                        {
                            if (file.Id == FileID)
                            {
                                return file;
                            }
                        }
                    }
                }
                return null;
            }
    private string GetFolderNameFromID(string FolderID, IList<Google.Apis.Drive.v3.Data.File> files)
            {
                string FolderName = "";
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        if (file.Id == FolderID)
                        {
                            FolderName = file.Name;
                        }
                    }
                }
                return FolderName;
            }
