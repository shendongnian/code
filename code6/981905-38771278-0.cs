    public static UIImage GenerateImage(NSUrl videoUrl)
	{
			var asset = AVAsset.FromUrl(videoUrl);
			var imageGenerator = AVAssetImageGenerator.FromAsset(asset);
			imageGenerator.AppliesPreferredTrackTransform = true;
			var actualTime = asset.Duration;
			CoreMedia.CMTime cmTime = new CoreMedia.CMTime(1, 60);
			NSError error;
			var imageRef = imageGenerator.CopyCGImageAtTime(cmTime, out actualTime, out error);
			if (imageRef == null)
				return null;
			var image = UIImage.FromImage(imageRef);
			return image;
	}
