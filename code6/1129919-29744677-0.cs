     private void DrawHand(HandState handState, Point handPosition, DrawingContext drawingContext)
        {
            switch (handState)
            {
                case HandState.Closed:
                    drawingContext.DrawEllipse(this.handClosedBrush, null, handPosition, HandSize, HandSize);
                    // Distance calculation
                    foreach (var body in bodies)
                    {
                        // Get the positions
                        pRH = body.Joints[JointType.HandRight];
                        pLH = body.Joints[JointType.HandLeft]; // pLH gets to be "home" position in the meanwhile
                        //Some maths
                        double sqDistance = Math.Pow(pRH.Position.X - pLH.Position.X, 2) +
                            Math.Pow(pRH.Position.Y - pLH.Position.Y, 2) +
                            Math.Pow(pRH.Position.Z - pLH.Position.Z, 2);
    
    
                        // This is the information I want to send to public class Monitor
                        double distance = Math.Sqrt(sqDistance);
                        // Create object of Monitor class and pass the distance 
                        Moniotr obj = new Monitor(distance);
                    }
                    break;
            }
        }
