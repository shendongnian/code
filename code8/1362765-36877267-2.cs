    using (Image imgFromFile = Image.FromFile(images[countimages])) {
    	Bitmap bmp = new Bitmap(imgFromFile.Width, imgFromFile.Height);
    	using (Graphics g = Graphics.FromImage(bmp)) {
    		g.DrawImage(imgFromFile, new Point(0, 0));
    	}
    	pictureBox1.Image = bmp;
    }
