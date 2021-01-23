	var url = e.Info[UIImagePickerController.ReferenceUrl] as NSUrl;
	var asset = new ALAssetsLibrary();
	UIImage image;
	asset.AssetForUrl(
		url, 
		(ALAsset obj) =>
		{
			var assetRep = obj.DefaultRepresentation;
			var cGImage = assetRep.GetFullScreenImage();
			image = new UIImage(cGImage);
			// Do something with "image" here... i.e.: assign it to a UIImageView
            imageView.Image = image;
		}, 
		(NSError err) => 
		{ 
			Console.WriteLine(err);
		}
	);
