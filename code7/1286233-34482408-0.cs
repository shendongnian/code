		private void button1_Click(object sender, EventArgs e) {
			Image original = Image.FromFile(Application.StartupPath + "\\ChessSet_Orig.JPG");
			Image resized = ResizeImage(original, new Size(200, 200));			
			FileStream fileStream = new FileStream(Application.StartupPath + "\\ChessSet_resized.JPG", FileMode.Create); //I use file stream instead of Memory stream here
			resized.Save(fileStream, ImageFormat.Jpeg);
			fileStream.Close(); //close after use
		}
		public static Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true) {
			int newWidth;
			int newHeight;
			if (preserveAspectRatio) {
				int originalWidth = image.Width;
				int originalHeight = image.Height;
				float percentWidth = (float)size.Width / (float)originalWidth;
				float percentHeight = (float)size.Height / (float)originalHeight;
				float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
				newWidth = (int)(originalWidth * percent);
				newHeight = (int)(originalHeight * percent);
			} else {
				newWidth = size.Width;
				newHeight = size.Height;
			}
			Image newImage = new System.Drawing.Bitmap(image, newWidth, newHeight); // I specify the new image from the original together with the new width and height
			using (Graphics graphicsHandle = Graphics.FromImage(image)) {
				graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphicsHandle.DrawImage(newImage, 0, 0, newWidth, newHeight);
			}
			return newImage;
		}
