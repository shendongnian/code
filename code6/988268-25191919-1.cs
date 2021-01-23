        private void LayoutRoot_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            if (e.DeltaManipulation.Scale.X > 0.0 && e.DeltaManipulation.Scale.Y > 0.0)
            {
                // Scale in the X direction
                double tmp = ImageTransform.ScaleX * ((e.DeltaManipulation.Scale.X + e.DeltaManipulation.Scale.Y) / 2);
                if (tmp < 1.0)
                    tmp = 1.0;
                else if (tmp > 4.0)
                    tmp = 4.0;
                ImageTransform.ScaleX = tmp;
                // Scale in the Y direction
                tmp = ImageTransform.ScaleY * ((e.DeltaManipulation.Scale.X + e.DeltaManipulation.Scale.Y) / 2);
                if (tmp < 1.0)
                    tmp = 1.0;
                else if (tmp > 4.0)
                    tmp = 4.0;
                ImageTransform.ScaleY = tmp;
            }
        }
        private void img_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            // First make sure we're translating and not scaling (one finger vs. two)
            if (e.DeltaManipulation.Scale.X == 0.0 && e.DeltaManipulation.Scale.Y == 0.0)
            {
                Image photo = sender as Image;
                TranslateTransform transform = photo.RenderTransform as TranslateTransform;
                // Compute the new X component of the transform
                double x = transform.X + e.DeltaManipulation.Translation.X;
                double y = transform.Y + e.DeltaManipulation.Translation.Y;
                
                // Apply the computed value to the transform
                transform.X = x;
                transform.Y = y;
            }
        }
        private void img_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            if (e.IsInertial)
            {
                Image photo = sender as Image;
                // Compute the inertial distance to travel
                double dx = e.FinalVelocities.LinearVelocity.X / 10.0;
                double dy = e.FinalVelocities.LinearVelocity.Y / 10.0;
                TranslateTransform transform = photo.RenderTransform as TranslateTransform;
                double x = transform.X + dx;
                double y = transform.Y + dy;
                // Apply the computed value to the animation
                PanAnimation.To = x;
                // Trigger the animation
                Pan.Begin();
            }
        } 
