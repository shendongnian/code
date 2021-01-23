            RotateTransform3D rotateTransform = new RotateTransform3D();
            RotateTransform3D rotateTransform2 = new RotateTransform3D();
            Transform3DGroup  transGroup = new Transform3DGroup();
            transGroup.Children.Add(rotateTransform);
            transGroup.Children.Add(rotateTransform2);
           // 3D Objects
            wire_2.Transform = transGroup;
            wire_235235235.Transform = transGroup;
            wire_3.Transform = transGroup;
            wire_4.Transform = transGroup;
          
            // Set Center
            rotateTransform.CenterZ = 2.33;
            rotateTransform2.CenterZ = 2.33;
            // Axis rotation Selection
            AxisAngleRotation3D rotateAxis = new AxisAngleRotation3D(new Vector3D(0,1 ,0 ) , 180);
            AxisAngleRotation3D rotateAxis2 = new AxisAngleRotation3D(new Vector3D(0, 0, -1), 180);        
            
         
            Rotation3DAnimation rotateAnimation = new Rotation3DAnimation(rotateAxis, TimeSpan.FromSeconds(2));          
            Rotation3DAnimation rotateAnimation2 = new Rotation3DAnimation(rotateAxis2, TimeSpan.FromSeconds(2));
            rotateAnimation.RepeatBehavior = RepeatBehavior.Forever;
            rotateAnimation.IsCumulative = true;
            rotateAnimation2.RepeatBehavior = RepeatBehavior.Forever;
            rotateAnimation2.IsCumulative = true;
            // Animation
            //  !HERE!
            rotateAnimation.BeginAnimation(RotateTransform3D.RotationProperty, rotateAnimation2);
            // it should be:  rotateAnimation2.BeginAnimation.....              
            rotateAnimation2.BeginAnimation(RotateTransform3D.RotationProperty, rotateAnimation2);
            //  ^^^^^^^
            rotateTransform.BeginAnimation(RotateTransform3D.RotationProperty, rotateAnimation);
