    public class PlayerBackgroundColorValueConverter : MvxColorValueConverter
    {    
        protected override MvxColor Convert(object value, object parameter, System.Globalization.CultureInfo culture)
        {
            var playerListType = (PlayerListType)parameter;
            if (parameter != null && playerListType == PlayerListType.AllPlayers)
                return BusinessConstants.Top10BGColor;
            
            if ((int)value <= 10)
                return BusinessConstants.Top10BGColor;
            ...
        }
    }
