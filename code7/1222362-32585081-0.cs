			Control targetControl = this.pictureBoxCurrentFrameL;
			String imageFile = "Image.JPG";
			//Update control styles, works for forms, not for controls. I solve this later otherwise .
			//this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			//this.SetStyle(ControlStyles.Opaque, true);
			//this.SetStyle(ControlStyles.ResizeRedraw, true);
			//Get requested debug level
			SlimDX.Direct2D.DebugLevel debugLevel = SlimDX.Direct2D.DebugLevel.None;
			//Resources for Direct2D rendering
			SlimDX.Direct2D.Factory d2dFactory = new SlimDX.Direct2D.Factory(SlimDX.Direct2D.FactoryType.Multithreaded, debugLevel);
			//Create the render target
			SlimDX.Direct2D.WindowRenderTarget d2dWindowRenderTarget = new SlimDX.Direct2D.WindowRenderTarget(d2dFactory, new SlimDX.Direct2D.WindowRenderTargetProperties() {
				Handle = targetControl.Handle,
				PixelSize = targetControl.Size,
				PresentOptions = SlimDX.Direct2D.PresentOptions.Immediately
			});
			//Paint!
			d2dWindowRenderTarget.BeginDraw();
			d2dWindowRenderTarget.Clear(new SlimDX.Color4(Color.LightSteelBlue));
			//Convert System.Drawing.Bitmap into SlimDX.Direct2D.Bitmap!
			System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)Properties.Resources.Image_720p;
			SlimDX.Direct2D.Bitmap d2dBitmap = null;
			System.Drawing.Imaging.BitmapData bitmapData = bitmap.LockBits(new Rectangle(new Point(0, 0), bitmap.Size), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);//TODO: PixelFormat is very important!!! Check!
			SlimDX.DataStream dataStream = new SlimDX.DataStream(bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, true, false);
			SlimDX.Direct2D.PixelFormat d2dPixelFormat = new SlimDX.Direct2D.PixelFormat(SlimDX.DXGI.Format.B8G8R8A8_UNorm, SlimDX.Direct2D.AlphaMode.Premultiplied);
			SlimDX.Direct2D.BitmapProperties d2dBitmapProperties = new SlimDX.Direct2D.BitmapProperties();
			d2dBitmapProperties.PixelFormat = d2dPixelFormat;
			d2dBitmap = new SlimDX.Direct2D.Bitmap(d2dWindowRenderTarget, new Size(bitmap.Width, bitmap.Height), dataStream, bitmapData.Stride, d2dBitmapProperties);
			bitmap.UnlockBits(bitmapData);
			//Draw SlimDX.Direct2D.Bitmap
			d2dWindowRenderTarget.DrawBitmap(d2dBitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));/**/
			d2dWindowRenderTarget.EndDraw();
			
			//Dispose everything u dont need anymore.
			//bitmap.Dispose();//......
