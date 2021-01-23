    class LoadAttachmentAsyncConverter : IValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, string language)
        {
            Task<BitmapImage> taskToExecute = GetImage(<some parameter>);
            //Possibly handle some other business logic
            return new NotifyTaskCompletion<BitmapImage>(taskToExecute);
        }
        public async Task<BitmapImage> GetImage(object someParameter) {
            BitmapImage image = new BitmapImage();
            //do (async stuff) to fill the image;
            return image;
        }
    }
