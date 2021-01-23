    public async Task<StorageFile> GetFile( string fileName )
        {
            // throw new NotImplementedException();
            var _folder = ApplicationData.Current.LocalFolder;
            try
            {
              var _file = await _folder.GetFileAsync(fileName);
                return _file;
            }
            catch
            {
               throw;
            }
            return null;
        }
