    ...
    var window = KinectCoreWindow.GetForCurrentThread();
    window.PointerMoved += window_PointerMoved;
    ...
    void window_PointerMoved(object sender, KinectPointerEventArgs e)
    {
        if ((!rightHand && e.CurrentPoint.Properties.HandType == HandType.LEFT) ||
            (rightHand && e.CurrentPoint.Properties.HandType == HandType.RIGHT))
        {
             //do something with this hand pointer's location
        }
    }
    void _bodyReader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
    {
        //get and check frame
        //...
        using (frame)
        {
            frame.GetAndRefreshBodyData(_bodies);
            foreach(Body body in _bodies)
            {
                if(body.IsTracked)
                {
                    CameraSpacePoint left = body.Joints[JointType.HandLeft].Position;
                    CameraSpacePoint right = body.Joints[JointType.HandRight].Position;
                    
                    if (left.Y > right.Y)
                        rightHand = false;
                    else
                        rightHand = true;
                    
                    break; //for this example I'm just looking at the first
                           //tracked body - other handling is required if you
                           //want to keep track of more than one body's hands
                }
            }
        }
    }
