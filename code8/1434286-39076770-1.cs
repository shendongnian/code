        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Minimize here before hiding. . 
            this.WindowState = WindowState.Minimized;  //this is the key
            this.Visibility = Visibility.Hidden;
            this.Dispatcher.BeginInvoke(DispatcherPriority.SystemIdle, new Action(() =>
            {                
                CaptureImage();
            }));            
        }
        private void CaptureImage()
        {
            System.Drawing.Rectangle bounds = new System.Drawing.Rectangle(0, 0, (int)System.Windows.SystemParameters.PrimaryScreenWidth, (int)System.Windows.SystemParameters.PrimaryScreenHeight);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(System.Drawing.Point.Empty, System.Drawing.Point.Empty, bounds.Size);
                }
                bitmap.Save("test.jpg", ImageFormat.Jpeg);
            }
        }
