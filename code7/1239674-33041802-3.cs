        private void Button_Click(object sender, EventArgs e) {
            var source = new Bitmap(pictureBox1.Image);
            //create a blank bitmap the same size as original
            var bmpInvert = new Bitmap(source.Width, source.Height);
 
            //get a graphics object from the new image
            using (var g = Graphics.FromImage(bmpInvert))
            {
                // create some image attributes
                var attributes = new System.Drawing.Imaging.ImageAttributes();
                attributes.SetColorMatrix(m_colorMatrix);
                g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height),
                            0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attributes);
                pictureBox1.Image = bmpInvert;
            }
        }
