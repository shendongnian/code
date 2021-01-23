            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = 0,
                To = rect1.ActualWidth*2,
                Duration = TimeSpan.FromSeconds(5)
            };
            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                From = 0,
                To = rect1.ActualHeight*2,
                Duration = TimeSpan.FromSeconds(5)
            };
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(Rectangle.WidthProperty));
            Storyboard.SetTarget(widthAnimation, rect1);
            Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(Rectangle.HeightProperty));
            Storyboard.SetTarget(heightAnimation, rect1);
            Storyboard buttonEnlargeStoryboard = new Storyboard();
            buttonEnlargeStoryboard.SpeedRatio = 1;
            buttonEnlargeStoryboard.Children.Add(widthAnimation);
            buttonEnlargeStoryboard.Children.Add(heightAnimation);
            buttonEnlargeStoryboard.Begin();
