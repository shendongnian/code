    namespace CSharpWPF
    {
        class ViewModel : DependencyObject
        {
            public ViewModel()
            {
                Images = new ObservableCollection<CollageImage>();
                GenerateCollage();
            }
            public ObservableCollection<CollageImage> Images { get; private set; }
            public void GenerateCollage()
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                var uriSource = new Uri(@"desert.jpg", UriKind.Relative);
                for (int i = 0; i < 10; i++)
                {
                    CollageImage img = new CollageImage();
                    img.Left = (0.2 + rand.NextDouble()) % 0.8;
                    img.Top = (0.2 + rand.NextDouble()) % 0.8;
                    img.Width = 100 + rand.NextDouble() * 100;
                    img.Height = 100 + rand.NextDouble() * 100;
                    img.Image = "desert.jpg";
                    img.Angle = rand.NextDouble() * 360;
                    Images.Add(img);
                }
            }
        }
        class CollageImage
        {
            public string Image { get; set; }
            public double Left { get; set; }
            public double Top { get; set; }
            public double Width { get; set; }
            public double Height { get; set; }
            public double Angle { get; set; }
        }
        class ImageLocationConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                double value = (double)values[0];
                double max = (double)values[1];
                return value * max;
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
