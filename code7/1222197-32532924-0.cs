    namespace Mynamespace.issecret
    {
      public class MyClass: IValueConverter
      {
           public bool OsCheck()
           {
               System.OperatingSystem os = System.Environment.OSVersion;
               //Get version information about the os.
               System.Version vs = os.Version;
               if ((os.Platform == PlatformID.Win32NT) &&
                   (vs.Major == 6) &&
                   (vs.Minor != 0))
               {
                   return true; //operatingSystem == "7";
               }
               return false;
           }
          public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
          {
              return OsCheck() ? Visibility.Collapsed : Visibility.Visible;
          }
          public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
          {
              throw new NotImplementedException();
          }
      }
    }
