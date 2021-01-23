    public enum GridState { Valid, Invalid }
    
    c
    
    private GridState _gridBackground;
    public GridState GridBackground
    { 
        get { return _gridBackground; }
        set
        {
            _gridBackground = value;
            NotifyPropertyChanged();
        }
    }
    ...
    public class GridStateToBackgroundColorConverter : IValueConverter
	{
		#region IValueConverter Members
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			GridState val = (GridState) value;
            if(val == GridState.Valid)
                return Brushes.Green;
            return Brushes.Red;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
		#endregion
	}
    ...
    <Grid Background="{Binding GridBackground, Converter={StaticResource gridStateToBackgroundColorConverter}">
