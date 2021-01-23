    /// <summary>
    /// Converts the value of enums and then compares them
    /// </summary>
    public class ConvertedEnumComparer : IComparer
    {
        #region Fields
        private readonly Type _enumType;
        private readonly string _enumPropertyPath;
        private readonly IValueConverter _enumConverter;
        private readonly ListSortDirection _directionToSort;
        #endregion
        public ConvertedEnumComparer(IValueConverter enumConverter, ListSortDirection directionToSort, Type enumType, string enumPropertyPath)
        {
            _enumType = enumType;
            _enumPropertyPath = enumPropertyPath;
            _enumConverter = enumConverter;
            _directionToSort = directionToSort;
        }
        #region IComparer implementation
        public int Compare(object parentX, object parentY)
        {
            if (!_enumType.IsEnum)
            {
                return 0;
            }
            // extract enum names from the parent objects
            var enumX = TypeDescriptor.GetProperties(parentX)[_enumPropertyPath].GetValue(parentX);
            var enumY = TypeDescriptor.GetProperties(parentY)[_enumPropertyPath].GetValue(parentY);
            // convert enums
            object convertedX = _enumConverter.Convert(enumX, typeof(string), null, Thread.CurrentThread.CurrentCulture);
            object convertedY = _enumConverter.Convert(enumY, typeof(string), null, Thread.CurrentThread.CurrentCulture);
            // compare the converted enums
            return _directionToSort == ListSortDirection.Ascending
                                   ? Comparer.Default.Compare(convertedX, convertedY)
                                   : Comparer.Default.Compare(convertedX, convertedY) * -1;
        }
        #endregion
    }
