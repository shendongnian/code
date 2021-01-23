    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;
    using System.Globalization;
    using System.Windows;
    
    namespace KontaktySilver
    {
        public class BytesToImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            
            {
                if (value != null && value is byte[])
                {
                    byte[] bytes = value as byte[];
                    using(MemoryStream stream = new MemoryStream(bytes)){
                    BitmapImage image = new BitmapImage();
    
                    image.SetSource(stream);
                    MessageBox.Show("proba");
                    return image;
                    }
                }
    
                return null;
    
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
        }
    }
