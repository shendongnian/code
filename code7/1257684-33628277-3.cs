    public async Task<Metadata> GetFolderAsync(string strDirectoryPathName, dynamic varKnownFolder = null)
    {
         using (await _FolderPathToInfoMapSync.EnterAsync().ConfigureAwait(false))
         {
               Metadata objFolder;
               string strPathName = strDirectoryPathName;
               if (varKnownFolder == null)
               {
                   objFolder = await _Storage.Client.Files.GetMetadataAsync(strPathName);
               }
               else
               {
                   // The code enters HERE BECAUSE varKnownFolder is not null
                   _FolderPathToInfoMap.Add(strDirectoryPathName, varKnownFolder);
                }
          }
          return objFolder;
    }
