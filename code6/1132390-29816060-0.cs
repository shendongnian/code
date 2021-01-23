    public class MaxStringConverter : IValueConverter
    {
        public MaxStringConverter()
        {
            ReplaceChars = "...";
            MaxLenght = int.MaxValue;
        }
        public int MaxLength { get; set; }
        public string ReplaceChars { get; set; }
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            string val = (string)value;
            int replaceCharLength = ReplaceChars.Length;
            if(val.Lenght > MaxLength )
            {
                int middle = val.Lenght / 2;
                int textLenth = MaxLength - 2 * replaceCharLength;
                string textToReturn = val.Substring(middle - replaceCharLength , textLenth);
                return string.Format("{1}{0}{1}", textToReturn, ReplaceChars);
            }
        }
    }
