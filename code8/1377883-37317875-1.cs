    class ComboBoxVisibleConverter :IValueConverter
    {
         public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
         {
            EnumerationExtension.EnumerationMember enumerationMember = value as EnumerationExtension.EnumerationMember;
            if (enumerationMember == null )
                return null;
            if ((MyEnum)enumerationMember.Value == MyEnum.AlternativeToSecondEnumMember)
                return true; //The DataTrigger will collapse the ComboBoxItem because of the Value="true"
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
