    			BitmapImage newImage = new BitmapImage();
			newImage.BeginInit();
			newImage.UriSource = MyImage.UriSource;
			newImage.Rotation = Rotation.Rotate90;
			newImage.EndInit();
			JpegBitmapEncoder encoder = new JpegBitmapEncoder();
			string ImageName = Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), (Guid.NewGuid() + ".jpg"));
			encoder.Frames.Add(BitmapFrame.Create(newImage));
			using (var filestream = new FileStream(ImageName, FileMode.Create))
				encoder.Save(filestream);
			MyImage = new BitmapImage(new Uri(ImageName));
