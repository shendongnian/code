    var anim = new DoubleAnimation
      {
         From = 1920,
         To = 1,
      };
    rctMovingObject1.BeginAnimation(Canvas.LeftProperty, anim);
    rctMovingObject2.BeginAnimation(Canvas.LeftProperty, anim);
    rctMovingObject3.BeginAnimation(Canvas.LeftProperty, anim);
