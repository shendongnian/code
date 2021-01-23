    public class BooleanToVisibilityConverter : IValueConverter
    {
        public Visibility VisibilityIfTrue
        {
            get;set;
        }
    
        public Visibility VisibilityIfFalse
        {
            get;set;
        }
    
        public void Convert(object value...)
        {
            if ((bool)value == true)
            {
                return ValueIfTrue;
            }
            else
            {
                return ValueIfFalse;
            }
        }
    }
