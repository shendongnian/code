        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter == null)
                return string.Empty;
            return ControlMapping.getKey(parameter.ToString(), SelectedLanguage.LanguageID);
        }
