    namespace Test
    {
        public class MyCanvas : Canvas
        {
            public bool IsGridVisible = false;
            #region Dependency Properties
            public static DependencyProperty ZoomValueProperty = DependencyProperty.Register("ZoomValue", typeof(double), typeof(MyCanvas), new FrameworkPropertyMetadata(1d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnZoomValueChanged));
            public double ZoomValue
            {
                get
                {
                    return (double)GetValue(ZoomValueProperty);
                }
                set
                {
                    SetValue(ZoomValueProperty, value);
                }
            }
            private static void OnZoomValueChanged(DependencyObject Object, DependencyPropertyChangedEventArgs e)
            {
            }
            #endregion
            protected override void OnRender(System.Windows.Media.DrawingContext dc)
            {
                base.OnRender(dc);
                IsGridVisible = ZoomValue > 4.75 ? true : false;
                if (IsGridVisible)
                {
                    // Draw GridLines
                    Pen pen = new Pen(Brushes.Black, 1 / ZoomValue);
                    pen.DashStyle = DashStyles.Solid;
                    for (double x = 0; x < this.ActualWidth; x += 1)
                    {
                        dc.DrawLine(pen, new Point(x, 0), new Point(x, this.ActualHeight));
                    }
                    for (double y = 0; y < this.ActualHeight; y += 1)
                    {
                        dc.DrawLine(pen, new Point(0, y), new Point(this.ActualWidth, y));
                    }
                }
            }
            public MyCanvas()
            {
                DefaultStyleKey = typeof(MyCanvas);
            }
        }
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        
            private WriteableBitmap bitmap = new WriteableBitmap(500, 500, 96d, 96d, PixelFormats.Bgr24, null);
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                int size = 1;
                Random rnd = new Random(DateTime.Now.Millisecond);
                bitmap.Lock(); // Lock() and Unlock() could be moved to the DrawRectangle() method. Just do some performance tests.
                for (int y = 0; y < 500; y++)
                {
                    for (int x = 0; x < 500; x++)
                    {
                        byte colR = (byte)rnd.Next(256);
                        byte colG = (byte)rnd.Next(256);
                        byte colB = (byte)rnd.Next(256);
                        DrawRectangle(bitmap, size * x, size * y, size, size, Color.FromRgb(colR, colG, colB));
                    }
                }
                bitmap.Unlock(); // Lock() and Unlock() could be moved to the DrawRectangle() method. Just do some performance tests.
                Image.Source = bitmap; // This should be done only once
            }
            public void DrawRectangle(WriteableBitmap writeableBitmap, int left, int top, int width, int height, Color color)
            {
                // Compute the pixel's color
                int colorData = color.R << 16; // R
                colorData |= color.G << 8; // G
                colorData |= color.B << 0; // B
                int bpp = writeableBitmap.Format.BitsPerPixel / 8;
                unsafe
                {
                    for (int y = 0; y < height; y++)
                    {
                        // Get a pointer to the back buffer
                        int pBackBuffer = (int)writeableBitmap.BackBuffer;
                        // Find the address of the pixel to draw
                        pBackBuffer += (top + y) * writeableBitmap.BackBufferStride;
                        pBackBuffer += left * bpp;
                        for (int x = 0; x < width; x++)
                        {
                            // Assign the color data to the pixel
                            *((int*)pBackBuffer) = colorData;
                            // Increment the address of the pixel to draw
                            pBackBuffer += bpp;
                        }
                    }
                }
                writeableBitmap.AddDirtyRect(new Int32Rect(left, top, width, height));
            }
        }
    }
