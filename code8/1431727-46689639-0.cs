		var rotateImage = Image.FromStream(fileStream);
		switch (degree)
		{
			case eRotateImagem.Degree_90:
				rotateImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
				break;
			case eRotateImagem.Degree_180:
				rotateImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
				break;
			case eRotateImagem.Degree_270:
				rotateImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
				break;
		}
		int orientationId = 0x0112; //Image orientation
		int thumbnailOrientationId = 0x5029; //Thumbnail orientation
		int thumbnailBytes = 0x501B; //Thumbnail bytes
		if (rotateImage.PropertyIdList.Contains(orientationId))
		{
			rotateImage.RemovePropertyItem(orientationId);
		}
		if (rotateImage.PropertyIdList.Contains(thumbnailOrientationId))
		{
			rotateImage.RemovePropertyItem(thumbnailOrientationId);
		}
		if (rotateImage.PropertyIdList.Contains(thumbnailBytes))
		{
			rotateImage.RemovePropertyItem(thumbnailBytes);
		}
