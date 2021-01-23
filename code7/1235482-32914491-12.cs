    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Windows.Data;
    
    namespace TestPopWpfWindow
    {
    
        public class UsbDriveAvailableEnablerConverter : IMultiValueConverter
        {
    
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if (values == null || values.Count() != 2)
                    return false;
    
                var driveInfos = values[1] as List<DriveInfo>;
                var targetDrive = values[0] as string; 
                if (driveInfos == null || !driveInfos.Any() || string.IsNullOrEmpty(targetDrive))
                    return false;
                return driveInfos.Any(d => d.IsReady && d.Name == targetDrive);
            }
    
    
    
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
