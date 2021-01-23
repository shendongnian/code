    public class ImageDetails
    {
        public ImageDetails(string fileName)
        {
            this.ImageFile = fileName;
        }
        #region Properties
        private decimal _widthInCm;
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Sets the width in cm (note this is a user set to calculate cx. Leave blank for the class to calculate the cx based on pixels)
        /// </summary>
        public decimal WidthInCm
        {
            set { _widthInCm = value; }
        }
        private decimal _heightInCm;
        /// <summary>
        /// Sets the height in cm (note this is a user set to calculate cy. Leave blank for the class to calculate the cy based on pixels)
        /// </summary>
        public decimal HeightInCm
        {
            set { _heightInCm = value; }
        }
        
        const int emusPerInch = 914400;
        const int emusPerCm = 360000;
        /// <summary>
        /// Returns the width in EMUS (English Metric Units)
        /// </summary>
        public long cx
        {
            get
            {
                if (_widthInCm > 0)
                    return (long)Math.Round(_widthInCm * emusPerCm);
                else if (_image.Width > 0)
                    return (long)Math.Round((_image.Width / _image.HorizontalResolution) * emusPerInch);
                else
                {
                    throw new InvalidDataException("WidthInCm/WidthInPx has not been set");
                }
            }
        }
        /// <summary>
        /// Returns the height in EMUS (English Metric Units)
        /// </summary>
        public long cy
        {
            get
            {
                if (_heightInCm > 0)
                    return (long)decimal.Round(_heightInCm * emusPerCm);
                else if (_image.Height > 0)
                    return (long)Math.Round((_image.Height / _image.VerticalResolution) * emusPerInch);
                else
                {
                    throw new InvalidDataException("HeightInCm/HeightInPx has not been set");
                }
            }
        }
        public int WidthInPx
        {
            get { return _image.Width; }
        }
        public int HeightInPx
        {
            get { return _image.Height; }
        }
        private string _imageFileName;
        private Image _image;
        /// <summary>
        /// Sets the Image file name and loads the Image object for later use
        /// </summary>
        public string ImageFile
        {
            get { return _imageFileName; }
            set
            {
                _imageFileName = value;
                // Limiting the time the image file is open in case others require it
                using (var fs = new FileStream(value, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    _image = Image.FromStream(fs);
                }
            }
        }
        /// <summary>
        /// Allows direct read/write access to the internal Image Object
        /// </summary>
        public Image ImageObject
        {
            get { return _image; }
            set { _image = value; }
        }
        #endregion
        /// <summary>
        /// This method resizes the image and replaces the internal Drawing.Image object with the new size
        /// </summary>
        /// <param name="targetWidth">New target width in px. The aspect ratio is maintained</param>
        public  void ResizeImage(int targetWidth)
        {
            if (_image == null)
                throw new InvalidOperationException("The Image has not been referenced. Add an image first using .ImageFile or .ImageObject");
            double percent = (double)_image.Width / targetWidth;
            int destWidth = (int)(_image.Width / percent);
            int destHeight = (int)(_image.Height / percent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            try
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(_image, 0, 0, destWidth, destHeight);
            }
            finally
            {
                g.Dispose();
            }
            _image = (Image)b;
        }
    }
