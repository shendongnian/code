        private void MoveWindow(double beginfrom, double to)
        {
            var da = new DoubleAnimation {
                From = beginfrom,
                To = to,
                FillBehavior = FillBehavior.Stop,
                Duration = new Duration(TimeSpan.FromSeconds(0.3)),
                AccelerationRatio = 0.1
            };
            var storyBoard = new Storyboard();
            storyBoard.Children.Add(da);
            Storyboard.SetTarget(da, this); //this = your control object
            Storyboard.SetTargetProperty(da, new PropertyPath(LeftProperty));
            storyBoard.Begin();
        }
