    public class TrayImage
    {
        [XmlAttribute("id")]
        public string ID { get; set; }
        [XmlAttribute("data")]
        public string Data { get; set; }
        /// <summary>
        /// Create an Image from the Base64 Data
        /// </summary>
        internal System.Windows.Controls.Image SetupImage()
        {
            System.Windows.Controls.Image _Image = new System.Windows.Controls.Image();
            if (this.Data != null)
            {
                BitmapImage _BitmapImage = this.CreateBitmapImage();
                Bitmap _Bitmap = this.BitmapImage2Bitmap(_BitmapImage);
                // If the image is portrait, rotate it
                if (_Bitmap.Width < _Bitmap.Height)
                {
                    _Bitmap = this.RotateImage(_Bitmap, 90);
                }
                _Image.Source = this.BitmapToBitmapImage(_Bitmap);
            }
            return _Image;
        }
        /// <summary>
        /// Convert a Bitmap into a BitmapImage
        /// </summary>
        private BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            using (MemoryStream _MemoryStream = new MemoryStream())
            {
                bitmap.Save(_MemoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                _MemoryStream.Position = 0;
                BitmapImage _BitmapImage = new BitmapImage();
                _BitmapImage.BeginInit();
                _BitmapImage.StreamSource = _MemoryStream;
                _BitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                _BitmapImage.EndInit();
                return _BitmapImage;
            }
        }
        /// <summary>
        /// Convert a Base64 String into a BitmapImage
        /// </summary>
        private BitmapImage CreateBitmapImage()
        {
            byte[] _BinaryData = Convert.FromBase64String(this.Data);
            BitmapImage _ImageBitmap = new BitmapImage();
            _ImageBitmap.BeginInit();
            _ImageBitmap.StreamSource = new MemoryStream(_BinaryData);
            _ImageBitmap.EndInit();
            return _ImageBitmap;
        }
        /// <summary>
        /// Convert a BitmapImage into a Bitmap
        /// </summary>
        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream _OutStream = new MemoryStream())
            {
                BitmapEncoder _Encoder = new BmpBitmapEncoder();
                _Encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                _Encoder.Save(_OutStream);
                System.Drawing.Bitmap _Bitmap = new System.Drawing.Bitmap(_OutStream);
                return new Bitmap(_Bitmap);
            }
        }
        /// <summary>
        /// Rotate a Bitmap
        /// </summary
        private Bitmap RotateImage(Bitmap bitmap, float angle)
        {
            int _Width = bitmap.Width;
            int _Height = bitmap.Height;
            float _MoveX = (float)_Height / 2;
            // Create bitmap with Height / Width revered
            Bitmap _ReturnBitmap = new Bitmap(_Height, _Width);
            // Make a graphics object from the empty bitmap
            using (Graphics _Graphics = Graphics.FromImage(_ReturnBitmap))
            {
                // Move image along x axis
                _Graphics.TranslateTransform(_MoveX, 0);
                // Rotate image
                _Graphics.RotateTransform(angle);
                // Move image back along x axis
                // NB, now it's been rotated, the x and y axis have swapped from our perspective.
                _Graphics.TranslateTransform(0, -_MoveX);
                // Draw passed in image onto graphics object
                _Graphics.DrawImage(bitmap, new Point(0, 0));
            }
            return _ReturnBitmap;
        }
    }
