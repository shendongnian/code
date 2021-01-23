        PictureBox pb = default(PictureBox);
            int x = 0, y = 3000;
            foreach (Image img in imglist1.Images)
            {
                pb = new System.Windows.Forms.PictureBox();
                pb.Image = img;
                pb.Width = 1450;
                pb.Height = 1450;
                //x += 1000;
                y -= 1000;
                pb.Location = new System.Drawing.Point(x,y);
                //pb.Location.X = x;
                //pb.Location.Y = y;
                this.Controls.Add(pb);
            }
            
