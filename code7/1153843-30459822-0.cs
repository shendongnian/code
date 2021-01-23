        public static void Animate(List<DependencyObject> objects, EventHandler onComplete = null)
        {
            Storyboard sb = new Storyboard();
            foreach (DependencyObject obj in objects)
            {
                DoubleAnimation da = new DoubleAnimation();
                da.From = FromValue; // Set you From value
                da.To = ToValue; // Set your To value
                da.Duration = new Duration(TimeSpan.FromSeconds(2)); // Set your Duration
                // a.EasingFunction = anim.Func; Easing function
                // da.BeginTime = anim.BeginTime; Begin time for each DA
                Storyboard.SetTarget(da, obj);
                Storyboard.SetTargetProperty(da, new PropertyPath(/* this your Property path */));
                sb.Children.Add(da);
            }                        
            if (onComplete != null)
                sb.Completed += onComplete;
            sb.Begin();
        }
