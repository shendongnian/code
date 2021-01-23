    public static async Task<bool> SaveSetting(string Key, Object value)
            {
                var ms = new MemoryStream();
                DataContractSerializer serializer = new DataContractSerializer(value.GetType());
                serializer.WriteObject(ms, value);
                await ms.FlushAsync();
    
                ms.Seek(0, SeekOrigin.Begin);
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(Key, CreationCollisionOption.ReplaceExisting);
                using (Stream fileStream = await file.OpenStreamForWriteAsync())
                {
                    await ms.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                }
                return true;
            }
