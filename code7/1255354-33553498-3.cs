        int picWidth, picHeight;
        Timer timer1;
        DateTime oldfiledate;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick); //calls method
            timer1.Interval = 2000; // in miliseconds (1 second = 1000 millisecond)
            timer1.Start(); //starts timer
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ChangeImage(); //checking the file length every 2000 miliseconds
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
            InitTimer();
        }
        private void ChangeImage()
        {
            string filename = @"c:\image\display.tif";
            DateTime filedate = File.GetLastWriteTime(filename);
            if (filedate > oldfiledate)
            {
                FileInfo fi = new FileInfo(filename);
                byte[] buff = new byte[fi.Length];
                using (FileStream fs = File.OpenRead(filename))
                {
                    fs.Read(buff, 0, (int)fi.Length);
                }
                MemoryStream ms = new MemoryStream(buff);
                
                Bitmap img1 = new Bitmap(ms);
                pictureBox1.Image = img1;
                pictureBox1.Width = img1.Width;
                pictureBox1.Height = img1.Height;
                picWidth = pictureBox1.Width;
                picHeight = pictureBox1.Height;
                oldfiledate = filedate;
            }
        }
