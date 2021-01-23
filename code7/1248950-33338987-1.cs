            //Get Your Image from Picturebox
            Bitmap image1 = new Bitmap(pictureBox1.Image);
            //Clone it to another bitmap
            Bitmap image2 = (Bitmap)image1.Clone();
            //Mirroring
            image2.RotateFlip(RotateFlipType.RotateNoneFlipX);
            //Merge two images in bitmap image,
            Bitmap bitmap = new Bitmap(image1.Width + image2.Width, Math.Max(image1.Height, image2.Height));
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(image1, 0, 0);
                g.DrawImage(image2, image1.Width, 0);
            }
            //Show them in a picturebox
            pictureBox2.Image = bitmap;
