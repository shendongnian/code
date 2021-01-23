    struct ImageUploadLimits
    {
        private readonly int _totalImagesUploaded;
        private readonly int _totalBytesUploaded;
        public ImageUploadLimits(int totalImagesUploaded, int totalBytesUploaded)
        {
            _totalImagesUploaded = totalImagesUploaded;
            _totalBytesUploaded = totalBytesUploaded;
        }
        public bool BelowLimits
        {
            get { return _totalImagesUploaded < Settings.ImageUpload.MaximumImagesCanUploadInPeriod && _totalBytesUploaded < (Settings.ImageUpload.MaximumImageUploadMbInPeriod * 1000000); }
        }
        public ImageUploadLimits WithAdditionalFileUpload(int sizeBytes)
        {
            return new ImageUploadLimits(_totalImagesUploaded + 1, _totalBytesUploaded + sizeBytes);
        }
    }
