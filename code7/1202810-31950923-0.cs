    class InstanceFactoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = value.GetType();
    
            return Activator.CreateInstance(type);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
...
    <Window.Resources>
        <local:SettingsWindow x:Key="SettingsWnd"/>
        <local:InstanceFactoryConverter x:Key="InstanceFactoryConverter"/>
    </Window.Resources>
