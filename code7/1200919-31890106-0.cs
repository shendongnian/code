        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is System.Drawing.Icon)
            {
                var icon = value as System.Drawing.Icon;
                ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                    icon.Handle,
                    System.Windows.Int32Rect.Empty,
                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                img.Source = imageSource;
                return img;
            }
            return Binding.DoNothing;
        }
