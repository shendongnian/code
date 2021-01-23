             Storyboard sboard = new Storyboard();
             DoubleAnimation da = new DoubleAnimation
               {
                 From = 1,
                 To = 0,
                 AutoReverse = true,
                 RepeatBehavior = RepeatBehavior.Forever
               };
               Storyboard.SetTarget(da, urButton);
               Storyboard.SetTargetProperty(animation, new PropertyPath((object)UIElement.OpacityProperty));
               sboard.Children.Add(animation);
               sboard.Start()
