	public class KinectManager
	{
		// Active Kinect sensor
		private KinectSensor kinectSensor = null;
		// Reader for body frames
		private BodyFrameReader bodyFrameReader = null;
		// Array for the bodies
		private Body[] bodies = null;
		// index for the currently tracked body
		private int bodyIndex;
		// flag to asses if a body is currently tracked
		private bool bodyTracked = false;
		public KinectManager()
		{
			this.kinectSensor = KinectSensor.GetDefault();
			// open the reader for the body frames
			this.bodyFrameReader = this.kinectSensor.BodyFrameSource.OpenReader();
			// open the sensor
			this.kinectSensor.Open();
			this.bodyFrameReader.FrameArrived += this.Reader_FrameArrived;
		}
		// Handles the body frame data arriving from the sensor
		private void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
		{
			bool dataReceived = false;
			using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
			{
				if (bodyFrame != null)
				{
					if (this.bodies == null)
					{
						this.bodies = new Body[bodyFrame.BodyCount];
					}
					bodyFrame.GetAndRefreshBodyData(this.bodies);
					dataReceived = true;
				}
			}
			if (dataReceived)
			{
				Body body = null;
				if(this.bodyTracked) {
					if(this.bodies[this.bodyIndex].IsTracked) {
						body = this.bodies[this.bodyIndex];
					} else {
						bodyTracked = false;
					}
				}
				if(!bodyTracked) {
					for (int i=0; i<this.bodies.Length; ++i)
					{
						if(this.bodies[i].IsTracked) {
							this.bodyIndex = i;
							this.bodyTracked = true;
							break;
						}
					}
				}
				if (body != null && this.bodyTracked && body.IsTracked)
				{
					// body represents your single tracked skeleton
				}
			}
		}
	}
