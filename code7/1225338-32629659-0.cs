    public async Task<bool> FileExist(string FileName)
            {
                try
                {
                    var folders = ApplicationData.Current.LocalFolder;
                    var file = await folders.GetFileAsync(Path);
                    if (file.Path != null)
                        return false;
                    else
                        return true;
                }
                catch
                {
                    return true;
    
                }
            }
