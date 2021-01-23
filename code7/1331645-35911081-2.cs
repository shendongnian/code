    public class DGMultiValueConverter : IMultiValueConverter
	{
		#region IMultiValueConverter Members
		public object Convert( object[] values, Type targetType, object parameter, 
                               CultureInfo culture )
		{
			ObservableCollection<OwnObject> combinedCollection = 
               new ObservableCollection<OwnObject>();
			foreach ( var item in values[0] as ObservableCollection<OwnObject> )
			{
				combinedCollection.Add( item );
			}
			foreach ( var item in values[1] as ObservableCollection<OwnObject> )
			{
				combinedCollection.Add( item );
			}
			return combinedCollection;
		}
		public object[] ConvertBack( object value, Type[] targetTypes, object parameter,
                                     CultureInfo culture )
		{
			throw new NotImplementedException();
		}
		#endregion
	}
