    public class whatever {
      ColorSpacePoint PreviousPoint;
      PreviousPoint.X = 0; 
      PreviousPoint.Y = 0; 
    
      Private Void EventHandlerForMovingKinect(args e) {
    
        line.X1 = PreviousPoint.X; // ERROR 'Use of possibly Unassigned field X'   
        line.Y1 = PreviousPoint.Y; // ERROR 'Use of possibly Unassigned field Y'   
        line.X2 = handtipPoint.X;                                 
        line.Y2 = handtipPoint.Y;                            
        PreviousPoint = handtipPoint;                        
        canvas.Children.Add(line);
      }
    }
