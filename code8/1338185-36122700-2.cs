    public class whatever {
      private ColorSpacePoint PreviousPoint;
      // set the initial values, so you don't get a uninstantiated object error.
      PreviousPoint.X = 0; 
      PreviousPoint.Y = 0; 
    
      Private Void EventHandlerForMovingKinect(args e) {
        // If there is some sort of event handler that fires each time your move the kinect or whatever, we can put the rest of the code here.
        line.Y1 = PreviousPoint.Y;    
        line.X2 = handtipPoint.X;                                 
        line.Y2 = handtipPoint.Y;                            
        PreviousPoint = handtipPoint;                        
        canvas.Children.Add(line);
      }
    }
