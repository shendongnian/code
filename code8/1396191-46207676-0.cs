    public async static Task<IFile> AsStorageFileAsync(this byte[] byteArray, string fileNameEx)
        {
            IFile file = await StorageData.LocalStorage().CreateFileAsync(fileNameEx, CreationCollisionOption.ReplaceExisting);
            using (var fileHandler = await file.OpenAsync(FileAccess.ReadAndWrite))
            {              
                byte[] dataBuffer = byteArray;
                await fileHandler.WriteAsync(dataBuffer, 0, dataBuffer.Length);
            }
            return file;
        }
