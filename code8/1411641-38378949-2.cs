    class FileStorage : IFileStorage
    {
        private AmazonS3 _amazon;
        public FileStorage(AmazonS3 amazon) { _amazon = amazon }
        void StoreFile(string file, string key)
        {
                _amazon.StoreFile(file, key);
        }
    }
