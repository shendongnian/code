    private void StartFaceTracting(Body body)
        {
            // Face
            _faceFrameSource = new FaceFrameSource(KinectSensor.GetDefault())
            {
                FaceFrameFeatures = FaceFrameFeatures.BoundingBoxInColorSpace | FaceFrameFeatures.PointsInColorSpace,
                TrackingId = body.TrackingId
            };
            _faceFrameSource.TrackingIdLost += _faceFrameSource_TrackingIdLost;
            _faceFrameReader = _faceFrameSource.OpenReader();
            _faceFrameReader.FrameArrived += _faceFrameReader_FrameArrived;
            Log.Info("Facetracking strated Id: " + body.TrackingId);
        }
