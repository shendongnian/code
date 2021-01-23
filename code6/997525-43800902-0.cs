    using System;
    using System.Globalization;
    using System.Windows.Data;
    namespace Rittal.RiZone.GUI.ValueConverters
    {
        public class LongToShortMonthConverter : IValueConverter
        {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Long month name from InvariantCulture</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Short text representation of the month in CurrentCulture; null in case no match was found</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            DateTime month;
            return DateTime.TryParseExact(
                value.ToString(),
                "MMMM",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out month)
                ? month.ToString("MMM", CultureInfo.CurrentCulture)
                : null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Short month name from CurrentCulture</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Long text representation of the month in InvariantCulture; null in case no match was found</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            DateTime month;
            return DateTime.TryParseExact(
                value.ToString(),
                "MMM",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out month)
                ? month.ToString("MMMM", CultureInfo.InvariantCulture)
                : null;
        }
    }
}
