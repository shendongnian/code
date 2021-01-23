            // update the face frame source to track this body
            if (FaceFrameSources[bodyFrameIndex].TrackingId != trackingId)
            {
                FaceFrameSources[bodyFrameIndex].TrackingId = trackingId;
            }
            //set all the tracking face data to false
            // update the high definition face frame source to track this body / face
            if (_highDefinitionFaceFrameSources[bodyFrameIndex].TrackingId != trackingId)
            {
                _highDefinitionFaceFrameSources[bodyFrameIndex].TrackingId = trackingId;
            }
