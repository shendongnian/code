        int picWidth, picHeight;
        Timer timer1;
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
        }
        private void ChangeImage()
        {
            string path = @"C:\image\";
            string[] filename = Directory.GetFiles(path, "*.tif"); //gets a specific image doc.
            pictureBox1.ImageLocation=filename[0];
            pictureBox1.Load();
            pictureBox1.Refresh();
            Bitmap img1 = new Bitmap(pictureBox1.Image as Bitmap);
            pictureBox1.Width = img1.Width;
            pictureBox1.Height = img1.Height;
            picWidth = pictureBox1.Width;
            picHeight = pictureBox1.Height;
        }
