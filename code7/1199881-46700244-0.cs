    public class GenderToImageConverter : IValueConverter
    {
        public object Convert(object value, object parameter, CultureInfo cultureInfo)
       {
            Gender gender = (Gender)value;
            if(gender == Gender.Female)
                return "male.png";
            else
                return "female.png";
       }
    }
