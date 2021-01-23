     private void ActivateTimer ( )
        {
            myTimer.Interval = 1000;
            myTimer.Enabled = true;
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Start();
        }
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            
            var image = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            var font = new Font("TimesNewRoman", 30, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString("Hi", font, Brushes.White, new Point(350, 0));
            this.pictureBox1.Image = image;
           
            graphics.DrawString("Tell me your name...", font, Brushes.White, new Point(100, 0));
            this.pictureBox1.Image = image;
                    
           
           
        }
