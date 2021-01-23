    private void bodyFrameReader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            var dataReceived = false;
            using (var bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
                {
                    if (_bodies == null)
                    {
                        _bodies = new Body[bodyFrame.BodyCount];
                    }
                    bodyFrame.GetAndRefreshBodyData(_bodies);
                    dataReceived = true;
                }
            }
            if (dataReceived)
            {
                foreach (var body in _bodies)
                {
                    if(!body.IsTracked)
                        continue;
                    if (_player == null)
                        PlayerFound(body);                    
                }
            }
        }
