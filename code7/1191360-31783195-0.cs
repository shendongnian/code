    Timer takeScreen;
    // This is a button to start the screen capturing
    private void Button_Play_Click(object sender, RoutedEventArgs e)
		{
			int fps = 30;
			takeScreen = new Timer(o => addNewImage(), null, 0, 1000 / fps);
		}
    private void addNewImage()
		{
			using (Bitmap bmp = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height))
			{
				using (Graphics gr = Graphics.FromImage(bmp))
				{
					gr.CopyFromScreen(0, 0, 0, 0, new System.Drawing.Size(bmp.Width, bmp.Height));
					Image_Preview.Dispatcher.Invoke(new Action(() => Image_Preview.Source = loadBitmap(bmp)));
				}
			}
		}
    public BitmapSource loadBitmap(System.Drawing.Bitmap source)
		{
			BitmapSource bmpf = null;
			using (MemoryStream ms = new MemoryStream())
			{
				using (WrappingStream ws = new WrappingStream(ms))
				{
					source.Save(ws, System.Drawing.Imaging.ImageFormat.Bmp);
					bmpf = BitmapFrame.Create(ws, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
				}
			}
			return bmpf;
		}
