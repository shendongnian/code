    private WriteableBitmap _bmp;
        private byte[] _pixelData;
        private Image _img;
        private int _stride;
        private int _width, _height;
        const int BYTES_OF_PIXEL = 4;
        private Random _random;
        private Mutex _mutex = new Mutex();
    
        public MainWindow()
        {
          InitializeComponent();
          Width = 480;
          Height = 320;
          canvas.Width = Width;
          canvas.Height = Height;
          WindowStartupLocation = WindowStartupLocation.CenterScreen;
          _random = new Random();
          _width = (int)this.Width;
          _height = (int)this.Height;
    
          var pixelCount = _width * _height;
    
          _bmp = new WriteableBitmap(_width, _height, 96, 96, PixelFormats.Bgra32, null); // writeable bmp
          _pixelData = new byte[pixelCount * BYTES_OF_PIXEL]; // all pixels
          _stride = _width * BYTES_OF_PIXEL; // bytes per row
          _img = new Image(); // displayed image
    
          RenderOptions.SetBitmapScalingMode(_img, BitmapScalingMode.LowQuality);
          RenderOptions.SetEdgeMode(_img, EdgeMode.Aliased);
          canvas.Children.Add(_img);
    
          var progress = new Progress<object>(_ =>
          {
            _bmp.WritePixels(new Int32Rect(0, 0, _width, _height), _pixelData,_stride, 0);
            _img.Source = _bmp;
          });
    
          var bufferTask = Task.Factory.StartNew(() => Process(progress));
        }
    
        private void Process(IProgress<object> progress)
        {
          while (true)
          {
            var a = (byte) _random.Next(255);
            var r = (byte) _random.Next(255);
            var g = (byte) _random.Next(255);
            var b = (byte) _random.Next(255);
            var color = Color.FromArgb(a, r, g, b);
    
            for (var y = 0; y < _height; y++)
            {
              for (var x = 0; x < _width; x++)
              {
                var index = (y*_stride) + (x*4);
                _pixelData[index] = color.B;
                _pixelData[index + 1] = color.G;
                _pixelData[index + 2] = color.R;
                _pixelData[index + 3] = color.A;
              }
            }
    
            progress.Report(null);
            Task.Delay(1000);
          }
        }
