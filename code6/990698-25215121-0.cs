      Private List<PictureBox> objeto = new List<PictureBox>();
     
        private void button1_Click(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(Application.StartupPath + @"/Images", "*.gif");                          
            int x = 20;
            int y = 600;
            var rand = new Random();
            for (int i = 0; i < 10; i++) 
             {
                x += 90;
                PictureBox pBox = new PictureBox();                
                pBox.Height = 80;
                pBox.Width = 50;
                pBox.Location = new System.Drawing.Point(x, y);
                objeto.Add(pBox);
                pBox.SizeMode = PictureBoxSizeMode.StretchImage;                
                Controls.Add(pBox);
                pBox.Image = System.Drawing.Bitmap.FromFile(files[rand.Next(files.Length)]);
            }
        }        
    }       
