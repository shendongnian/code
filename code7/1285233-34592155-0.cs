    public async Task<string> GetBase64(string name)
            {
                StorageFolder folder = ApplicationData.Current.LocalFolder;
                StorageFile file = await folder.GetFileAsync(name);
                var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(file.Path));
    
                byte[] fileBytes = null;
                using (var stream = await file.OpenReadAsync())
                {
                    fileBytes = new byte[stream.Size];
                    using (var reader = new DataReader(stream))
                    {
                        await reader.LoadAsync((uint)stream.Size);
                        reader.ReadBytes(fileBytes);
                    }
                }
    
               return Convert.ToBase64String(fileBytes);
            }
