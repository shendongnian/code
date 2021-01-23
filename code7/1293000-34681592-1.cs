            float drawBorderX = 5;
            float drawBorderY = 5;
            //Set up our two images
            Bitmap barCode = Code128Rendering.MakeBarcodeImage(textBox1.Text, 2, true);
            Bitmap text = new Bitmap(barCode.Width, 50);
            Graphics textGraphics = Graphics.FromImage(text);
            
            //Draw the text to the bottom image.
            FontStyle sitil = FontStyle.Bold;
            Font fonts = new Font(new FontFamily("Arial"), 10, sitil);
            textGraphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, text.Width, text.Height));
            textGraphics.DrawString(textBox1.Text, fonts, Brushes.Black, drawBorderX, drawBorderY);
            //Vertically concatenate the two images.
            Bitmap resultImage = new Bitmap(Math.Max(barCode.Width, text.Width), barCode.Height + text.Height);
            Graphics g = Graphics.FromImage(resultImage);
            g.DrawImage(barCode, 0, 0);
            g.DrawImage(text, 0, barCode.Height);
