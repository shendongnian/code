		private void Search()
		{
			SearchKeywordInRedPixels("xyz", "F:\\pam\\Wallpapers\\red.jpg");
		}
		private void SearchKeywordInRedPixels(string keyword, string imagePath)
		{
			Bitmap image = new Bitmap(imagePath);
			byte[] keywordBytes = Encoding.ASCII.GetBytes(keyword);
			Point firstMatchingBytePos;
			int currentByteIndex = 0;
			for (int y = 0; y < image.Height; y++)
			{
				for (int x = 0; x < image.Width; x++)
				{
					Color pixel = image.GetPixel(x, y);
					if (pixel.R == keywordBytes[currentByteIndex])
					{
						if (currentByteIndex == 0)
							firstMatchingBytePos = new Point(x, y);
						if (currentByteIndex == keyword.Length - 1)
						{
							KeywordFound(keyword, firstMatchingBytePos);
							currentByteIndex = 0;
						}
						else
						{
							currentByteIndex++;
						}
					}
					else
					{
						currentByteIndex = 0;
					}
				}
			}
		}
		private void KeywordFound(string keyword, Point pos)
		{
			string msg = String.Concat("Keyword ", keyword, "found at ", pos);
			MessageBox.Show(msg);
		}
