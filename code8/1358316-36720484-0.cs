		[Export ("initWithFrame:")]
		public ProductCell (CGRect frame) : base (frame)
		{
			BackgroundView = new UIView{ BackgroundColor = UIColor.DarkGray };
			SelectedBackgroundView = new UIView{ BackgroundColor = UIColor.Green };
			ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
			ContentView.Layer.BorderWidth = 2.0f;
			ContentView.BackgroundColor = UIColor.Gray;
			cellViewContainer = new UIView ();
			cellViewContainer.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			imageView = new UIImageView (UIImage.FromBundle ("placeholder.png"));
			productName = new UILabel {
				Text = "Name",
				TextColor = UIColor.Black,
				BackgroundColor = UIColor.White,
				TextAlignment = UITextAlignment.Center
			};
			price = new UILabel {
				Text = "Price",
				TextColor = UIColor.Black,
				BackgroundColor = UIColor.Red,
				TextAlignment = UITextAlignment.Center
			};
			var labelHeight = (ContentView.Bounds.Height - 2) / 2;
			var labelWidth = (ContentView.Bounds.Width - 2 ) / 2;
			productName.Frame = new CGRect(5, 5, labelWidth, labelHeight);
			price.Frame = new CGRect(5, labelHeight, labelWidth, labelHeight);
			imageView.Frame = new CGRect (labelWidth, 0, labelWidth, ContentView.Bounds.Height - 2); 
			ContentView.AddSubviews (new UIView[] { imageView, productName, price });
		}
