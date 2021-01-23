        private void btn_scan_Click(object sender, EventArgs e)
        {
            try
            {
                //get list of devices available
                List<string> devices = WIAScanner.GetDevices();
                List<Image> images = null;
                //check if device is not available
                if (devices.Count == 0)
                {
                    MessageBox.Show("You do not have any WIA devices.");
                    this.Close();
                }
                else
                {
                    if (devices.Count == 1)
                    {
                        images = WIAScanner.Scan(devices[0]);
                    }
                    else
                    {
                        images = WIAScanner.Scan();
                    }
                }
                //get images from scanner
                foreach (Image image in images)
                {
                    var path = String.Format(@"C:\Temp\scan{0}_{1}.jpg", DateTime.Now.ToString("yyyy-MM-dd HHmmss"), Path.GetRandomFileName());
                    image.Save(path, ImageFormat.Jpeg);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
