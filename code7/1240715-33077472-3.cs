    void rotateTimer_Tick(object sender, object e)
    {
        RotateTransform transform = mainrocket_img.RenderTransform as RotateTransform;
        if (transform == null)
        {
            transform = new RotateTransform();
            mainrocket_img.RenderTransform = transform;
        }
        double doubleAngle = transform.Angle;
    }
