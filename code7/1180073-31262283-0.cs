    _grabber = new Capture();
    ....
    //on frame requested:
    Image<Brg, byte> currentFrame = _grabber.QueryFrame();
    Bitmap bitmap = currentFrame.Bitmap; //System.Drawing
    public class BitmapToImageSourceConverter: IValueConverter
    {
        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            var bitmap = (Bitmap) value;
            var hBitmap = bitmap.GetHbitmap();
            using (var handle = new SafeHBitmapHandle(hBitmap, true))
            {
                 if (handle.IsInvalid) return null;
                 return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                     handle.DangerousGetHandle(),
                     IntPtr.Zero,
                     Int32Rect.Empty,
                     BitmapSizeOptions.FromEmptyOptions());
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
