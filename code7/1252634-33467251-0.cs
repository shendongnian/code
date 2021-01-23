    public class FileIconConverter : IValueConverter
    {
        public DataTemplate FileIconTemplate { get; set; }
        public DataTemplate FolderIconTemplate { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is Directory)
            {
                return this.FolderIconTemplate;
            }
            if (value is File)
            {
                return this.FileIconTemplate;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
