    void rotateTimer_Tick(object sender, object e)
    {
        RotateTransform transform = mainrocket_img.RenderTransform as RotateTransform;
		if(transform == null){
			mainrocket_img.RenderTransform = new RotateTransform();
		}
        double doubleAngle = transform.Angle;
    }
