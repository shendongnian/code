    Grid gd = this.FindName("SecondaryGrid") as Grid;
            DoubleAnimationUsingKeyFrames dm = new DoubleAnimationUsingKeyFrames();
            LinearDoubleKeyFrame l1 = new LinearDoubleKeyFrame();
            LinearDoubleKeyFrame l2 = new LinearDoubleKeyFrame();
            l1.Value = -703.203;
            l1.KeyTime = TimeSpan.FromSeconds(0);
            l2.Value = 0;
            l2.KeyTime = TimeSpan.FromSeconds(1);
            dm.KeyFrames.Add(l1);
            dm.KeyFrames.Add(l2);
            dm.Duration = new Duration(TimeSpan.FromMilliseconds(30000));
            Storyboard sb = new Storyboard();
            sb.Children.Add(dm);
            Storyboard.SetTarget(dm, gd);
            Storyboard.SetTargetName(dm, gd.Name);
            Storyboard.SetTargetProperty(dm, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
            
            sb.Begin();
