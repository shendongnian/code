            TextBlock txt = new TextBlock();            
            txt.Text = "Sample";
            txt.HorizontalAlignment = HorizontalAlignment.Center;
            txt.VerticalAlignment = VerticalAlignment.Center;
            RotateTransform r1 = new RotateTransform();
            txt.RenderTransform = r1;
            MainGrid.Children.Add(txt);  //MainGrid is the name of your main layout
            var rotateAnimation = new DoubleAnimation(0, 270, TimeSpan.FromSeconds(5));
            rotateAnimation.RepeatBehavior = RepeatBehavior.Forever;
            var rt = (RotateTransform)txt.RenderTransform;
            rt.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
