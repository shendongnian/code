    var anim = new DoubleAnimation
      {
         From = 1920,
         To = 1,
         Duration =new Duration(new TimeSpan(0,0,2))// a duration of 2 seconds 
      };
    rctMovingObject1.BeginAnimation(Canvas.LeftProperty, anim);
    rctMovingObject2.BeginAnimation(Canvas.LeftProperty, anim);
    rctMovingObject3.BeginAnimation(Canvas.LeftProperty, anim);
