    public class FilenameToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string fileName = value as string;
            if (fileName != null)
            {
                WriteableBitmap bitmap = new WriteableBitmap(200, 200);
                using (IsolatedStorageFile myIsoStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream fileStream = myIsoStorage.OpenFile(fileName, FileMode.Open, FileAccess.Read))
                    {
                        //StreamResourceInfo sri = Application.GetResourceStream(fileStream);
                        bitmap = PictureDecoder.DecodeJpeg(fileStream);
                    }
                }
                return bitmap;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
