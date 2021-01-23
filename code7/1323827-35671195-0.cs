    public partial class MainWindow : Window
        {
            private FilterInfoCollection VideoCaptureDevices;
            private VideoCaptureDevice FinalVideo;
            public VideoFileWriter writer= new VideoFileWriter();
            
            public MainWindow()
            {
                InitializeComponent();
    
                VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
                {
                    comboBox1.Items.Add(VideoCaptureDevice.Name);
                }
                comboBox1.SelectedIndex = 0;
    
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                writer.Open(@"d:\\newVid.avi", 640, 480, 25, VideoCodec.MPEG4);
    
                FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[comboBox1.SelectedIndex].MonikerString);
                FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
                FinalVideo.Start();
                
            }
    
            void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
            {
                
                System.Drawing.Image imgforms = (Bitmap)eventArgs.Frame.Clone();
    
                Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
    
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
    
                MemoryStream ms = new MemoryStream();
                imgforms.Save(ms, ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                
                bi.StreamSource = ms;
                bi.EndInit();            
    
                //Using the freeze function to avoid cross thread operations 
                bi.Freeze();
    
                //Calling the UI thread using the Dispatcher to update the 'Image' WPF control         
                Dispatcher.BeginInvoke(new ThreadStart(delegate
                {
                    pictureBox1.Source = bi; /*frameholder is the name of the 'Image' WPF control*/
                }));
    
                for (int i = 0; i < 2; i++)
                {
                    writer.WriteVideoFrame(bmp);
                }
                
            }
    
            private void Stop_Click(object sender, RoutedEventArgs e)
            {
                writer.Close();
                FinalVideo.Stop();
                this.Close();
            }
    
        }
