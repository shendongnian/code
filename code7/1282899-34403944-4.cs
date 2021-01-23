    /// <summary>
    /// Provides functions to save and load single object as well as List of 'T' using serialization
    /// </summary>
    /// <typeparam name="T">Type parameter to be serialize</typeparam>
    public static class SerializableStorage<T> where T : new()
    {
        public static async void Save(string FileName, T _Data)
        {
            MemoryStream _MemoryStream = new MemoryStream();
            DataContractSerializer Serializer = new DataContractSerializer(typeof(T));
            Serializer.WriteObject(_MemoryStream, _Data);
            Task.WaitAll();
            StorageFile _File = await ApplicationData.Current.LocalFolder.CreateFileAsync(FileName, CreationCollisionOption.ReplaceExisting);
            using (Stream fileStream = await _File.OpenStreamForWriteAsync())
            {
                _MemoryStream.Seek(0, SeekOrigin.Begin);
                await _MemoryStream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                fileStream.Dispose();
            }
        }
        
        public static async Task<T> Load(string FileName)
        {
            StorageFolder _Folder = ApplicationData.Current.LocalFolder;
            StorageFile _File;
            T Result;
            try
            {
                Task.WaitAll();
                _File = await _Folder.GetFileAsync(FileName);
                using (Stream stream = await _File.OpenStreamForReadAsync())
                {
                    DataContractSerializer Serializer = new DataContractSerializer(typeof(T));
                    Result = (T)Serializer.ReadObject(stream);
                    
                }
                return Result;
            }
            catch (Exception ex)
            {
                return new T();
            }
        }
    }
