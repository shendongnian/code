    public class SumGroupConverter : IValueConverter
    {
         public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
         {
              GroupItem groupItem = value as GroupItem;
              CollectionViewGroup collectionViewGroup = groupItem.Content as CollectionViewGroup;
              int sum = 0;
    
              foreach (var item in collectionViewGroup.Items)
              {
                  DownloadManager dman = item as DownloadManager;
                  int size = 0;
                  int.TryParse(dman.Size, out size);
                  sum += size;
              }
    
              return string.Format("Total size: {0}", sum);
          }
    
          public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
          {
              throw new NotImplementedException();
          }
      }
