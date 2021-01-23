        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private Bitmap capturedImage;
        private String message = "";
        public FormQRCodeScanner()
        {
            InitializeComponent();
        }
        private void FormQRCodeScanner_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in videoDevices)
            {
                comboBoxCameraSource.Items.Add(device.Name);
            }
            comboBoxCameraSource.SelectedIndex = 0;
            videoSource = new VideoCaptureDevice();
            buttonStartStop.Text = "Start";
            buttonCapture.Enabled = false;
            buttonDecode.Enabled = false;
        }
        private void FormQRCodeScanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }
        
        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap) eventArgs.Frame.Clone();
            pictureBoxSource.Image = image;
        }
        
        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
                pictureBoxSource.Image = null;
                pictureBoxCaptured.Image = null;
                pictureBoxSource.Invalidate();
                pictureBoxCaptured.Invalidate();
                buttonStartStop.Text = "Start";
                buttonCapture.Enabled = false;
                buttonDecode.Enabled = false;
            }
            else
            {
                videoSource = new VideoCaptureDevice(videoDevices[comboBoxCameraSource.SelectedIndex].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                videoSource.Start();
                buttonStartStop.Text = "Stop";
                buttonCapture.Enabled = true;
                buttonDecode.Enabled = true;
            }
        }
        private void buttonCapture_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
            {
                pictureBoxCaptured.Image = (Bitmap)pictureBoxSource.Image.Clone();
                capturedImage = (Bitmap)pictureBoxCaptured.Image;
            }
        }
        private void buttonDecode_Click(object sender, EventArgs e)
        {
            if (capturedImage != null)
            {
                ExtractQRCodeMessageFromImage(capturedImage);
                richTextBoxMessage.Text = message;
                richTextBoxMessage.ReadOnly = true;
            }
        }
        private string ExtractQRCodeMessageFromImage(Bitmap bitmap)
        {
            try
            {
                BarcodeReader reader = new BarcodeReader
                    (null, newbitmap => new BitmapLuminanceSource(bitmap), luminance => new GlobalHistogramBinarizer(luminance));
                reader.AutoRotate = true;
                reader.TryInverted = true;
                reader.Options = new DecodingOptions { TryHarder = true };
                var result = reader.Decode(bitmap);
                if (result != null)
                {
                    message = result.Text;
                    return message;
                }
                else
                {
                    message = "QRCode couldn't be decoded.";
                    return message;
                }
            }
            catch (Exception ex)
            {
                message = "QRCode couldn't be detected.";
                return message;
            }
        }
