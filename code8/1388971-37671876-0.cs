    public class EditTextEnabledValueConverter : MvxValueConverter<bool, InputTypes>
    {
        protected override InputTypes Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value)
                return InputTypes.NumberFlagDecimal | InputTypes.NumberFlagSigned;
            return InputTypes.Null;
        }
    }
