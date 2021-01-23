    // Intermediate storage for the depth data received from the sensor
    private DepthImagePixel[] depthPixels;
    // Intermediate storage for the color data received from the camera
    private byte[] colorPixels;
    // Intermediate storage for the depth to color mapping
    private ColorImagePoint[] colorCoordinates;
    // Inverse scaling factor between color and depth
    private int colorToDepthDivisor;
    // Format we will use for the depth stream
    private const DepthImageFormat DepthFormat = DepthImageFormat.Resolution320x240Fps30;
    // Format we will use for the color stream
    private const ColorImageFormat ColorFormat = ColorImageFormat.RgbResolution640x480Fps30;
    //...
    // Initialization
    this.colorCoordinates = new ColorImagePoint[this.sensor.DepthStream.FramePixelDataLength];
    this.depthWidth = this.sensor.DepthStream.FrameWidth;
    this.depthHeight = this.sensor.DepthStream.FrameHeight;
    int colorWidth = this.sensor.ColorStream.FrameWidth;
    int colorHeight = this.sensor.ColorStream.FrameHeight;
    this.colorToDepthDivisor = colorWidth / this.depthWidth;
    this.sensor.AllFramesReady += this.SensorAllFramesReady;
    //...
	private void SensorAllFramesReady(object sender, AllFramesReadyEventArgs e)
	{
		// in the middle of shutting down, so nothing to do
		if (null == this.sensor)
		{
			return;
		}
		bool depthReceived = false;
		bool colorReceived = false;
		using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
		{
			if (null != depthFrame)
			{
				// Copy the pixel data from the image to a temporary array
				depthFrame.CopyDepthImagePixelDataTo(this.depthPixels);
				depthReceived = true;
			}
		}
		using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
		{
			if (null != colorFrame)
			{
				// Copy the pixel data from the image to a temporary array
				colorFrame.CopyPixelDataTo(this.colorPixels);
				colorReceived = true;
			}
		}
		if (true == depthReceived)
		{
			this.sensor.CoordinateMapper.MapDepthFrameToColorFrame(
				DepthFormat,
				this.depthPixels,
				ColorFormat,
				this.colorCoordinates);
			// ...
			int depthIndex = x + (y * this.depthWidth);
			DepthImagePixel depthPixel = this.depthPixels[depthIndex];
			// scale color coordinates to depth resolution
			int X = colorImagePoint.X / this.colorToDepthDivisor;
			int Y = colorImagePoint.Y / this.colorToDepthDivisor;
			// depthPixel is the depth for the (X,Y) pixel in the color frame
		}
	}
