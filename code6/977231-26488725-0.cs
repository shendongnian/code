		{
			base.ViewDidLoad ();
            
			float h = 50.0f;
			float w = 50.0f;
			float padding = 10.0f;
			int n = 25;
            
			_scrollView = new UIScrollView {
                Frame = new RectangleF (0, 0, View.Frame.Width, h + 2 * padding),
                ContentSize = new SizeF ((w + padding) * n, h),
                BackgroundColor = UIColor.DarkGray,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            };
         
			for (int i=0; i<n; i++) {
				var button = UIButton.FromType (UIButtonType.RoundedRect);
				button.SetTitle (i.ToString (), UIControlState.Normal);
				button.Frame = new RectangleF (padding * (i + 1) + (i * w), padding, w, h);
				_scrollView.AddSubview (button);
				_buttons.Add (button);
			}
            
			View.AddSubview (_scrollView);
		}
