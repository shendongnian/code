            System.Drawing.Image objImage = System.Drawing.Image.FromFile("1.gif");//From File
            int height = objImage.Height;//Actual image width
            int width = objImage.Width;//Actual image height
            FrameDimension dimension = new FrameDimension(objImage.FrameDimensionsList[0]);
            // Number of frames
            int frameCount = objImage.GetFrameCount(dimension);
            Bitmap[] Frames = new Bitmap[frameCount];
            // Copy the animation Bitmap frames into the Bitmap array
            for (int Index = 0; Index < frameCount; Index++)
            {
                // Set the current frame within the animation to be copied into the Bitmap array element
                objImage.SelectActiveFrame(FrameDimension.Time, Index);
                // Create a new Bitmap element within the Bitmap array in which to copy the next frame
                Frames[Index] = new Bitmap(objImage.Size.Width, objImage.Size.Height);
                // Copy the current animation frame into the new Bitmap array element
                Graphics.FromImage(Frames[Index]).DrawImage(objImage, new Point(0, 0));
                SolidBrush brush = new SolidBrush(Color.FromArgb(100, 255, 255, 255));
                System.Drawing.Bitmap bitmapimage = new System.Drawing.Bitmap(objImage, width, height);// create bitmap with same size of Actual image
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmapimage);
                //Adding watermark text on image
                string hex = "#ADADAD";
                Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                g.DrawString("www.Statckoverflow.com", new Font("Trebuchet MS", 10, System.Drawing.FontStyle.Bold), new SolidBrush(_color), 5, 5);
                g.DrawString("Copyright © Gitz", new Font("Trebuchet MS", 10, System.Drawing.FontStyle.Bold), new SolidBrush(_color), 5, 20);
            }
