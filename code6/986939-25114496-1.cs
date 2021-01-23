    public class YourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do whatever you want here
            ActiveProject project = value as ActiveProject;
            return project == null ? project.Name : "Whatever";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert back if needed
            throw new NotImplementedException();
        }
    }
