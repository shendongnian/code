        public async Task<bool> saveDataAsync<T>(T whichData, string dataFileName)
        {
            var Serializer = new DataContractSerializer(typeof(T));
            await mySemaphoreSlim.WaitAsync();
            try
            {
                using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(dataFileName, CreationCollisionOption.ReplaceExisting))
                {
                    Serializer.WriteObject(stream, whichData);
                }
            }
            finally
            {
                mySemaphoreSlim.Release();
            }
            return true;
        }
