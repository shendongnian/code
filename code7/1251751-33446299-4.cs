    public class SampleTimeConverter : IValueConverter
    {
      private double StartTime    = 0.0 ;
      private double SamplingRate = 20000.0 ;
      public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
      {
        ListViewItem item = (ListViewItem) value;
        ListView listView = ItemsControl.ItemsControlFromItemContainer(item) as ListView;
        int    index = listView.ItemContainerGenerator.IndexFromContainer(item);
        double sampleTime = StartTime + index / SamplingRate ;
        return String.Format ( "{0:F5}", sampleTime ) ;
      }
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
          throw new NotImplementedException();
      }
    }
