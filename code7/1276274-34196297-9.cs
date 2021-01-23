    public class ListToTables : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list =  value as List<List<string>>;
            var headers = list.First();
            DataTable dt = new DataTable();
            
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            foreach (List<string> row in list.Skip(1))
            {
                int index = 0;
                DataRow r = dt.NewRow();
                foreach (string col in row)
                {
                    r[index++] = col;
                }
                dt.Rows.Add(r);
            }
            return dt;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
